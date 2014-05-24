using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engine;
using Engine.LifetimePolicy;

namespace EngineTests
{
    class Dependency
    {
    }

    class Target
    {
        public Dependency Dependency { get; set; }

        public Target(Dependency dependency)
        {
            Dependency = dependency;
        }
    }
    
    [TestClass]
    public class TransientLifetimePolicyTest
    {
        [TestMethod]
        public void CreatesNewInstanceEachTime()
        {
            var container = new SimpleContainer();

            var policy = new TransientLifetimePolicy(typeof(ExampleClass), container);
            var instance1 = policy.GetInstance();
            var instance2 = policy.GetInstance();

            Assert.AreNotEqual(instance1, instance2);
            Assert.IsTrue(instance1 is ExampleClass);
            Assert.IsTrue(instance2 is ExampleClass);
        }

        [TestMethod]
        public void DealsWithDependencies()
        {
            var dependencyInstance = new Dependency();
            var container = new SimpleContainer();
            container.RegisterInstance<Dependency>(dependencyInstance);

            var policy = new TransientLifetimePolicy(typeof(Target), container);
            var instance = policy.GetInstance() as Target;

            Assert.IsNotNull(instance);
            Assert.AreEqual(dependencyInstance, instance.Dependency);
        }
    }
}
