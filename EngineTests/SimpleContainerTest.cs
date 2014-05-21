using Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTests
{
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
            container.RegisterType<IEnumerable<string>, List<string>>(false);
            var enumerable = container.Resolve<IEnumerable<string>>();
            Assert.IsNotNull(enumerable);
            Assert.IsTrue(enumerable is List<string>);
        }
    }
}
