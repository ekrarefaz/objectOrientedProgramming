using NUnit.Framework;
using ClockTask;

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

        public void SecondsTest()
        {
            for(int i = 0; i < 1; i++)
            {
                clock.TrackTicks();
            }

            Assert.AreEqual("00:00:01", clock.Time);
        }

        [Test]

        public void MinutesTest()
        {
            for (int i = 0; i < 60; i++)
            {
                clock.TrackTicks();
            }
            Assert.AreEqual("00:01:00", clock.Time);
        }

        [Test]

        public void HoursTest()
        {
            for(int i = 0; i < 3600; i++)
            {
                clock.TrackTicks();
            }
            Assert.AreEqual("01:00:00", clock.Time);
        }

        [Test]

        public void ResetTest()
        {
            clock.ClockReset();
            Assert.AreEqual("00:00:00", clock.Time);
        }

        [Test]

        public void RollOverCheck()
        {
            for (int i = 0; i < 86400; i++)
                clock.TrackTicks();
            Assert.AreEqual("00:00:00", clock.Time);
        }
        [Test]
        public void ReturnStringTest()
        {
            Assert.IsInstanceOf<string>(clock.Time);
        }
    }
}
