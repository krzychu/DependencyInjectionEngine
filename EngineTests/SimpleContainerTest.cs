using Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTests
{
    interface IInterface
    {
        
    }

    class Implementation : IInterface
    {
        
    }

    [TestClass]
    public class SimpleContainerTest
    {
        private SimpleContainer container;
        
        [TestInitialize]
        public void Initialize()
        {
            container = new SimpleContainer();
        }

        [TestMethod]
        public void CreatesInstancesOfRegisteredTypes()
        {
            container.RegisterType<ExampleClass>(false);
            var instance = container.Resolve<ExampleClass>();
            Assert.IsNotNull(instance);
            Assert.IsTrue(instance is ExampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(UnregisteredTypeException))]
        public void ThrowsExceptionWhenTypeWasNotRegistered()
        {
            container.Resolve<List<string>>();
        }

        [TestMethod]
        public void CreatesInstancesOfConcreteTypesWhenAskedForAbstractTypes()
        {
            container.RegisterType<IInterface, Implementation>(false);
            var enumerable = container.Resolve<IInterface>();
            Assert.IsNotNull(enumerable);
            Assert.IsTrue(enumerable is Implementation);
        }
    }
}
