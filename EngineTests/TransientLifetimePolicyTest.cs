using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engine;

namespace EngineTests
{
    [TestClass]
    public class TransientLifetimePolicyTest
    {
        [TestMethod]
        public void CreatesNewInstanceEachTime()
        {
            var policy = new TransientLifetimePolicy(typeof(ExampleClass));
            var instance1 = policy.GetInstance();
            var instance2 = policy.GetInstance();

            Assert.AreNotEqual(instance1, instance2);
            Assert.IsTrue(instance1 is ExampleClass);
            Assert.IsTrue(instance2 is ExampleClass);
        }
    }
}
