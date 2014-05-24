using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.LifetimePolicy
{
    public class TransientLifetimePolicy : LifetimePolicyBase
    {
        public TransientLifetimePolicy(Type type)
            : base(type)
        {
        }

        public override object GetInstance()
        {
            return Activator.CreateInstance(Type);
        }
    }
}
