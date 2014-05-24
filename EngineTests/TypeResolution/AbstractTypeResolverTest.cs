using Engine;
using Engine.TypeResolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTests.TypeResolution
{
    [TestClass]
    public class AbstractTypeResolverTest
    {
        [TestMethod]
        public void CallsContainerToResolveTypes()
        {
            var mockContainer = new Mock<IContainer>();
            var expectedInstance = new object();
            mockContainer
                .Setup(x => x.Resolve(typeof(object)))
                .Returns(expectedInstance);

            var resolver = new AbstractTypeResolver(typeof(object), mockContainer.Object);

            Assert.AreEqual(expectedInstance, resolver.Resolve());
        }
    }
}
