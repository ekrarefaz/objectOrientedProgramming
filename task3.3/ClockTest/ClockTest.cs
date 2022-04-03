using NUnit.Framework;
using Glock;

namespace ClockTest
{
    public class Tests
    {
        Clock clock = new Clock();

        [SetUp]
        public void Setup()
        {
            clock.ClockReset();
        }

        [Test]

        public void Test1()
        {
            clock.SecondsTest();
            Assert.AreEqual("00:00:01", clock.Time);
        }

        [Test]

        public void Test2()
        {
            clock.MinutesTest();
            Assert.AreEqual("00:01:00", clock.Time);
        }

        [Test]

        public void Test3()
        {
            clock.HoursTest();
            Assert.AreEqual("01:00:00", clock.Time);
        }

        [Test]

        public void Test4()
        {
            clock.ClockReset();
            Assert.AreEqual("00:00:00", clock.Time);
        }
        [Test]
        public void Test5()
        {
            clock.ClockResetTest();
            Assert.AreEqual("00:00:00", clock.Time);
        }
    }
}
