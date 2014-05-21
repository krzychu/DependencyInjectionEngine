using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class SingletonLifetimePolicy : LifetimePolicyBase
    {
        private object _instance;

        public SingletonLifetimePolicy(Type type)
            : base(type)
        {
        }

        public override object GetInstance()
        {
            if (_instance == null)
                _instance = Activator.CreateInstance(Type);

            return _instance;
        }
    }
}
