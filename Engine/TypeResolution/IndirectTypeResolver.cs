using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.TypeResolution
{
    public class IndirectTypeResolver : ITypeResolver
    {
        private Type _type;
        private SimpleContainer _container;

        public IndirectTypeResolver(Type type, SimpleContainer container)
        {
            _type = type;
            _container = container;
        }

        public object Resolve()
        {
            return _container.Resolve(_type);
        }
    }
}
