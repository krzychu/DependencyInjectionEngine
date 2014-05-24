using Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTests
{
    class A { };
    class B { };
    class C { };

    [TestClass]
    public class CycleDetectorTest
    {
        [TestMethod]
        [ExpectedException(typeof(CyclicDependencyException))]
        public void ThrowsExceptionWhenCycleExists()
        {
            var mockContainer = new Mock<IContainer>();
            mockContainer.Setup(x => x.GetDependencies(typeof(A)))
                .Returns(new[] { typeof(B) });

            mockContainer.Setup(x => x.GetDependencies(typeof(B)))
                .Returns(new[] { typeof(C) });
            
            mockContainer.Setup(x => x.GetDependencies(typeof(C)))
                .Returns(new[] { typeof(A) });

            CycleDetector.CheckForCycles(typeof(A), mockContainer.Object);
        }

        [TestMethod]
        public void DoesNotThrowWhenThereAreNoCycles()
        {
            var mockContainer = new Mock<IContainer>();
            mockContainer.Setup(x => x.GetDependencies(typeof(A)))
                .Returns(new[] { typeof(B) });

            mockContainer.Setup(x => x.GetDependencies(typeof(B)))
                .Returns(new[] { typeof(C) });

            CycleDetector.CheckForCycles(typeof(A), mockContainer.Object);
        }
    }
}
