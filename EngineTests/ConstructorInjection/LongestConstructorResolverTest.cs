using Engine.ConstructorInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTests.ConstructorInjection
{
    class SeveralConstructors
    {
        public SeveralConstructors()
        {
        }

        public SeveralConstructors(object parent, string name)
        {
        }

        public SeveralConstructors(object parent)
        {
        }
    }

    [TestClass]
    public class LongestConstructorResolverTest
    {
        [TestMethod]
        public void ReturnsConstructorWithMostArguments()
        {
            var resolver = new LongestConstructorResolver(null);
            var constructor = resolver.GetConstructor(typeof(SeveralConstructors));
            Assert.AreEqual(2, constructor.GetParameters().Length);
        }
    }
}
