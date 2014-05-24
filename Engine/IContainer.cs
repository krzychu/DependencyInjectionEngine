using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public interface IContainer
    {
        void RegisterType<T>(bool singleton)
            where T : class;

        void RegisterType<Abstract, Concrete>(bool singleton)
            where Concrete : Abstract;

        void RegisterInstance<T>(T instance);

        T Resolve<T>()
            where T : class;

        object Resolve(Type type);

        ConstructorInfo GetCorrectConstructor(Type type);

        IEnumerable<Type> GetDependencies(Type type);
    }
}
