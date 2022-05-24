using NUnit.Framework;
using ClockTask;

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
        public void TicksTest()
        {
            Assert.AreEqual(0, TestCounter.Ticks);
        }
        [Test]
        public void IncrementTest()
        {
            for (int i = 0; i <= 5; i++)
            {
                TestCounter.Increment();
            }
            Assert.AreEqual(6, TestCounter.Ticks);
        }
        [Test]
        public void ResetTest()
        {
            TestCounter.Reset();
            Assert.AreEqual(0, TestCounter.Ticks);
        }



    }
}
