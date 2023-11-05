using NUnit.Framework;
using CIDemo;

namespace CIDemo.Test
{
    [TestFixture]
    public class Tests
    {
        private Program _CIDemo;
        [SetUp]
        public void Setup()
        {
            _CIDemo = new Program();
        }

        [Test]
        public void Test1()
        {
            var result = _CIDemo.IsPrime(4);
            Assert.IsTrue(result, "4 Should be");
        }

        [Test]
        public void Test2()
        {
            var result = _CIDemo.IsPrime(3);
            Assert.IsFalse(result, "3 Should Not be");
        }
    }
}