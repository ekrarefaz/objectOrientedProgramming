using System;
namespace Glock
{
    public class Clock
    {
        private Counter _sec = new Counter();
        private Counter _min = new Counter();
        private Counter _hr = new Counter();

        public Clock()
        {

        }

        public Counter Seconds
        {
            get
            {
                return _sec;
            }
            set
            {
                _sec = value;
            }
        }
        public Counter Minutes
        {
            get
            {
                return _min;
            }
            set
            {
                _min = value;
            }
        }
        public Counter Hours
        {
            get
            {
                return _hr;
            }
            set
            {
                _hr = value;
            }
        }
        public void TrackSeconds()
        {
            if (Seconds.Ticks >= 59)
            {
                Seconds.Reset();
                Minutes.Increment();
            }
            else
            {
                Seconds.Increment();
            }
        }
        public void TrackMinutes()
        {

            if (Minutes.Ticks >= 59)
            {
                Minutes.Reset();
                Hours.Increment();
            }
        }

        public void TrackHours()
        {

            if(Hours.Ticks >= 24)
            {
                Seconds.Reset();
                Minutes.Reset();
                Hours.Reset();        
            }

        }
        public void TrackTime()
        {
            this.TrackSeconds();
            this.TrackMinutes();
            this.TrackHours();
        }
        public void ClockTime()
        {
            Console.WriteLine($"{Hours.Ticks:00}:{Minutes.Ticks:00}:{Seconds.Ticks:00}");

        }
        public string Time
        {
            get
            {
                return $"{Hours.Ticks:00}:{Minutes.Ticks:00}:{Seconds.Ticks:00}";
            }
        }



        // TEST Methods

        public void ClockReset()
        {
            Seconds.Reset();
            Minutes.Reset();
            Hours.Reset();
        }
        public void SecondsTest()
        {
            Seconds.Increment();
        }


        public void MinutesTest()
        {
            Minutes.Increment();
        }

        public void HoursTest()
        {
            Hours.Increment();
        }

        public void ClockResetTest()
        {
            for(int i = 0; i < 86400; i++)
            {
                ClockTime();
            }
        }
    }
}
