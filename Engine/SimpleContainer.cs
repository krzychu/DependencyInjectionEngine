using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class SimpleContainer
    {
        private Dictionary<Type, ILifetimePolicy> _policies = new Dictionary<Type, ILifetimePolicy>();

        public void RegisterType<T>(bool singleton) 
            where T : class
        {
            var type = typeof(T);
            RegisterType(singleton, type);
        }

        private void RegisterType(bool singleton, Type type)
        {
            if (singleton)
                _policies[type] = new SingletonLifetimePolicy(type);
            else
                _policies[type] = new TransientLifetimePolicy(type);
        }

        public void RegisterType<Abstract, Concrete>(bool singleton) 
            where Concrete : Abstract
        { 
            var concreteType = typeof(Concrete);
            var abstractType = typeof(Abstract);

            if (!_policies.ContainsKey(concreteType))
                RegisterType(singleton, concreteType);

            _policies[abstractType] = _policies[concreteType];
        }

        public void RegisterInstance<T>(T instance)
        {
            _policies[typeof(T)] = new SpecifiedInstanceLifetimePolicy(instance);            
        }

        public T Resolve<T>()
            where T : class
        {
            var type = typeof(T);
            if (!_policies.ContainsKey(type))
                throw new UnregisteredTypeException(type);

            return (T)_policies[type].GetInstance();
        }
    }
}
