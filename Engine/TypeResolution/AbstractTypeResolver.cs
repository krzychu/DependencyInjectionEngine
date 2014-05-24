using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.TypeResolution
{
    public class AbstractTypeResolver : ITypeResolver
    {
        private Type _type;
        private SimpleContainer _container;

        public AbstractTypeResolver(Type type, SimpleContainer container)
        {
            _type = type;
            Dependencies = new[] { type };
            _container = container;
        }

        public object Resolve()
        {
            return _container.Resolve(_type);
        }

        public IEnumerable<Type> Dependencies { get; private set; }
    }
}
