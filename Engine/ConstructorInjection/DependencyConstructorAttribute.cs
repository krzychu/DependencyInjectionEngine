using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ConstructorInjection
{
    [AttributeUsage(AttributeTargets.Constructor, Inherited = false, AllowMultiple = false)]
    sealed class DependencyConstructorAttribute : Attribute
    {
    }
}
