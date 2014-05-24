using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ConstructorInjection
{
    public class DependencyConstructorException : Exception
    {
        public DependencyConstructorException(string format, params object[] arts)
            : base(String.Format(format, arts))
        {
        }
    }
}
