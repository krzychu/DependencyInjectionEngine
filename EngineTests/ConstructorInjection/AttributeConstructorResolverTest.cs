using Engine.ConstructorInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Reflection;

namespace EngineTests.ConstructorInjection
{
    class AmbiguiousAttributes
    {
        [DependencyConstructor]
        public AmbiguiousAttributes()
        {
        }

        [DependencyConstructor]
        public AmbiguiousAttributes(object parent)
        {
        }
    }

    class UnambigiousAttributes
    {
        [DependencyConstructor]
        public UnambigiousAttributes()
        {
        }

        public UnambigiousAttributes(object parent)
        {
        }
    }

    class NoAttributes
    {
    }

    [TestClass]
    public class AttributeConstructorResolverTest
    {
        [TestMethod]
        [ExpectedException(typeof(DependencyConstructorException))]
        public void ThrowsExceptionWhenThereAreTwoMarkedConstructors()
        {
            AttributeConstructorResolver resolver = new AttributeConstructorResolver(null);
            resolver.GetConstructor(typeof(AmbiguiousAttributes));
        }

        [TestMethod]
        public void FindsCorrectConstructorIfOneIsMarked()
        {
            var resolver = new AttributeConstructorResolver(null);
            Assert.AreEqual(0, resolver.GetConstructor(typeof(UnambigiousAttributes)).GetParameters().Length);
        }

        [TestMethod]
        public void DelegatesResolvingToNextIfNoConstructorIsMarked()
        {
            var next = new Mock<AbstractConstructorResolver>(null);
            next
                .Setup(x => x.GetConstructor(typeof(NoAttributes)))
                .Returns(() => null);

            var resolver = new AttributeConstructorResolver(next.Object);
            Assert.AreEqual(null, resolver.GetConstructor(typeof(NoAttributes)));
        }
    }
}
