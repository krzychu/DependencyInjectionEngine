using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public class UnregisteredTypeException : Exception
    {
        public UnregisteredTypeException(Type type)
            : base(String.Format("Type {0} was not registered", type.FullName))
        {
        }
    }
}
