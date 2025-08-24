using ApartmentManagementSystem.Contracts.Services;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
//Identity
using Identity.Application;
using Identity.Controller;
using Identity.Infrastracture;
//Property
using Property.Application;
using Property.Controller;
using Property.Infrastracture;
//Leasing
using Leasing.Application;
using Leasing.Controller;
using Leasing.Infrastracture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
     .AddApplicationPart(typeof(AuthenticationController).Assembly)
     .AddApplicationPart(typeof(BuildingsController).Assembly)
     .AddApplicationPart(typeof(TenantsController).Assembly);

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((doc, ctx, ct) =>
    {
        doc.Components ??= new();
        doc.Components.SecuritySchemes["BearerAuth"] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization"
        };
        return Task.CompletedTask;
    });

    options.AddOperationTransformer((op, ctx, ct) =>
    {
        var hasAuth = ctx.Description.ActionDescriptor?.EndpointMetadata?
            .OfType<Microsoft.AspNetCore.Authorization.IAuthorizeData>()
            .Any() == true;

        if (hasAuth)
        {
            op.Security ??= new List<OpenApiSecurityRequirement>();
            op.Security.Add(new OpenApiSecurityRequirement
            {
                [new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    { Type = ReferenceType.SecurityScheme, Id = "BearerAuth" }
                }] = Array.Empty<string>()
            });
        }
        return Task.CompletedTask;
    });
});


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Identity.Application.AssemblyReference).Assembly);
});

//Register Dependency Injection

//Identity
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddIdentityApplication();
//Property
builder.Services.AddPropertyInfrastructure(builder.Configuration);
builder.Services.AddPropertyApplication();
//Leasing
builder.Services.AddLeasingInfrastructure(builder.Configuration);
builder.Services.AddLeasingApplication();



builder.Services.AddScoped<IEventBus, EventBus>();
builder.Services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapScalarApiReference();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
