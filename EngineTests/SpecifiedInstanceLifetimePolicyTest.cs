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
    public class SpecifiedInstanceLifetimePolicyTest
    {
        [TestMethod]
        public void AlwaysReturnsGivenInstance()
        {
            var instance = new ExampleClass();
            var policy = new SpecifiedInstanceLifetimePolicy(instance);

            Assert.AreEqual(instance, policy.GetInstance());
            Assert.AreEqual(instance, policy.GetInstance());
        }
    }
}
