using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class LifetimePolicyBase : ILifetimePolicy
    {
        protected Type Type { get; private set; }

        public LifetimePolicyBase(Type createdType)
        {
            if (createdType == null)
                throw new ArgumentNullException("createdType");

            if (createdType.IsValueType)
                throw new ArgumentException("Only reference types can be produced");
            
            Type = createdType;
        }

        public abstract object GetInstance();
    }
}
