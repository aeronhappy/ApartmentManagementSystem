using System.Reflection;

namespace Ownership.Application
{
    public class AssemblyReference
    {
        public static  Assembly Assembly => typeof(AssemblyReference).Assembly;
    }
}
