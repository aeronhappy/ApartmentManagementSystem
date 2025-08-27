using System.Reflection;

namespace Property.Application
{
    public class AssemblyReference
    {
        public static  Assembly Assembly => typeof(AssemblyReference).Assembly;
    }
}
