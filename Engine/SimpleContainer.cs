using Engine.ConstructorInjection;
using Engine.LifetimePolicy;
using Engine.TypeResolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class SimpleContainer : IContainer
    {
        private Dictionary<Type, ITypeResolver> _resolvers = new Dictionary<Type, ITypeResolver>();
        private AbstractConstructorResolver _constructorResolver;

        public SimpleContainer()
        {
            _constructorResolver = null;
        }

        public ConstructorInfo GetCorrectConstructor(Type type)
        {
            return _constructorResolver.GetConstructor(type);
        }

        public IEnumerable<Type> GetDependencies(Type type)
        {
            if (!_resolvers.ContainsKey(type))
                throw new UnregisteredTypeException(type);

            return _resolvers[type].Dependencies;
        }

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
                policy = new SingletonLifetimePolicy(type, this);
            else
                policy = new TransientLifetimePolicy(type, this);

            _resolvers[type] = new ConcreteTypeResolver(policy);
        }

        public void RegisterType<Abstract, Concrete>(bool singleton) 
            where Concrete : Abstract
        { 
            var concreteType = typeof(Concrete);
            var abstractType = typeof(Abstract);

            if (!_resolvers.ContainsKey(concreteType))
                RegisterType(singleton, concreteType);

            _resolvers[abstractType] = new AbstractTypeResolver(concreteType, this);
        }

        public void RegisterInstance<T>(T instance)
        {
            _resolvers[typeof(T)] = new ConcreteTypeResolver(new SpecifiedInstanceLifetimePolicy(instance));            
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
