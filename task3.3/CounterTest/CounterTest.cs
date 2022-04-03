using NUnit.Framework;
using Glock;

namespace CounterTest
{
    public class Tests
    {
        Counter TestCounter = new Counter();
        [SetUp]
        public void Setup()
        {
            TestCounter.Reset();
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(0, TestCounter.Ticks);
        }
        [Test]
        public void Test2()
        {
            for(int i = 0; i <= 5; i++)
            {
                TestCounter.Increment();
            }
            Assert.AreEqual(6, TestCounter.Ticks);
        }
        [Test]
        public void Test3()
        {
            TestCounter.Reset();
            Assert.AreEqual(0, TestCounter.Ticks);
        }



    }
}
