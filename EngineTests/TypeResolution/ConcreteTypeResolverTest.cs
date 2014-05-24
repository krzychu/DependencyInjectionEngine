using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Engine.LifetimePolicy;
using Engine.TypeResolution;

namespace EngineTests.TypeResolution
{
    [TestClass]
    public class ConcreteTypeResolverTest
    {
        [TestMethod]
        public void UsesPolicyToGetObject()
        {
            var mockPolicy = new Mock<ILifetimePolicy>();
            var returnValue = new object();
            mockPolicy
                .Setup(x => x.GetInstance())
                .Returns(returnValue);

            var resolver = new ConcreteTypeResolver(mockPolicy.Object);

            Assert.AreEqual(returnValue, resolver.Resolve());
        }
    }
}
