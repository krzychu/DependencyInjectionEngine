using Engine.ConstructorInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.LifetimePolicy
{
    public class SingletonLifetimePolicy : LifetimePolicyBase
    {
        private object _instance;

        public SingletonLifetimePolicy(Type type, SimpleContainer container)
            : base(type, container)
        {
        }

        public override object GetInstance()
        {
            if (_instance == null)
                _instance = CreateInstance();

            return _instance;
        }
    }
}
