using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class CyclicDependencyException : Exception
    {
        public CyclicDependencyException(Type type)
            : base(type.FullName)
        {
        }
    }
}
