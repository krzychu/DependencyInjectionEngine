using Engine.LifetimePolicy;
using Engine.TypeResolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class SimpleContainer
    {
        private Dictionary<Type, ITypeResolver> _resolvers = new Dictionary<Type, ITypeResolver>();

        public void RegisterType<T>(bool singleton) 
            where T : class
        {
            var type = typeof(T);
            RegisterType(singleton, type);
        }

        private void RegisterType(bool singleton, Type type)
        {
            ILifetimePolicy policy = null;
            if (singleton)
                policy = new SingletonLifetimePolicy(type);
            else
                policy = new TransientLifetimePolicy(type);

            _resolvers[type] = new DirectTypeResolver(policy);
        }

        public void RegisterType<Abstract, Concrete>(bool singleton) 
            where Concrete : Abstract
        { 
            var concreteType = typeof(Concrete);
            var abstractType = typeof(Abstract);

            if (!_resolvers.ContainsKey(concreteType))
                RegisterType(singleton, concreteType);

            _resolvers[abstractType] = new IndirectTypeResolver(concreteType, this);
        }

        public void RegisterInstance<T>(T instance)
        {
            _resolvers[typeof(T)] = new DirectTypeResolver(new SpecifiedInstanceLifetimePolicy(instance));            
        }

        public T Resolve<T>()
            where T : class
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            if (!_resolvers.ContainsKey(type))
                throw new UnregisteredTypeException(type);

            return _resolvers[type].Resolve();
        }
    }
}
