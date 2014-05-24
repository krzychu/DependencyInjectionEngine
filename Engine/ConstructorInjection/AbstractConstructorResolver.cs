using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ConstructorInjection
{
    public abstract class AbstractConstructorResolver
    {
        public AbstractConstructorResolver Next { get; private set; }

        public AbstractConstructorResolver(AbstractConstructorResolver next)
        {
            Next = next;
        }

        public abstract ConstructorInfo GetConstructor(Type type);
    }
}
