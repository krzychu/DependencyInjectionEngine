using Engine.ConstructorInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.LifetimePolicy
{
    public class TransientLifetimePolicy : LifetimePolicyBase
    {
        public TransientLifetimePolicy(Type type, SimpleContainer container)
            : base(type, container)
        {
        }

        public override object GetInstance()
        {
            return CreateInstance();
        }
    }
}
