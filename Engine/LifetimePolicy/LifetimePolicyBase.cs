using Engine.ConstructorInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine.LifetimePolicy
{
    public abstract class LifetimePolicyBase : ILifetimePolicy
    {
        private ConstructorInfo _constructor;
        private IContainer _container;

        protected Type Type { get; private set; }

        public LifetimePolicyBase(Type createdType, IContainer container)
        {
            Type = createdType;
            _constructor = container.GetCorrectConstructor(createdType);
            _container = container;
        }

        protected object CreateInstance()
        {
            var resolvedParameters = _constructor
                .GetParameters()
                .Select(x => _container.Resolve(x.ParameterType))
                .ToArray();

            return _constructor.Invoke(resolvedParameters);
        }

        public abstract object GetInstance();

        public IEnumerable<Type> Dependencies { get; private set; }
    }
}
