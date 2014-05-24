using Engine;
using Engine.LifetimePolicy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTests
{
    [TestClass]
    public class SingletonLifetimePolicyTest
    {
        [TestMethod]
        public void TheSameInstanceIsReturnedEachTime()
        {
            var container = new SimpleContainer();
            var policy = new SingletonLifetimePolicy(typeof(ExampleClass), container);
            var instance1 = policy.GetInstance();
            var instance2 = policy.GetInstance();

            Assert.AreEqual(instance1, instance2);
            Assert.IsTrue(instance1 is ExampleClass);
            Assert.IsTrue(instance2 is ExampleClass);
        }
    }
}
