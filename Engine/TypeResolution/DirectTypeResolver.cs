using Engine.LifetimePolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.TypeResolution
{
    public class DirectTypeResolver : ITypeResolver
    {
        private ILifetimePolicy _policy;

        public DirectTypeResolver(ILifetimePolicy policy)
        {
            _policy = policy;
        }

        public object Resolve()
        {
            return _policy.GetInstance();
        }
    }
}
