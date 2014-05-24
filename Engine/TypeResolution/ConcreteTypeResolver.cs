using Engine.LifetimePolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.TypeResolution
{
    public class ConcreteTypeResolver : ITypeResolver
    {
        private ILifetimePolicy _policy;

        public ConcreteTypeResolver(ILifetimePolicy policy)
        {
            _policy = policy;
        }

        public object Resolve()
        {
            return _policy.GetInstance();
        }

        public IEnumerable<Type> Dependencies
        {
            get { return _policy.Dependencies; }
        }
    }
}
