using System;
namespace ClockTask
{
    public class Clock
    {
        private Counter _sec = new Counter();
        private Counter _min = new Counter();
        private Counter _hr = new Counter();

        public Clock()
        {

        }
        public void TrackTicks()
        {
               if (_sec.Ticks >= 59)
               {
                   _sec.Reset();
                   if (_min.Ticks >= 59)
                   {
                       _min.Reset();
                       if (_hr.Ticks >= 23)
                       {
                           ClockReset();
                       }
                       else
                       {
                           _hr.Increment();
                       }
                   }
                   else
                   {
                       _min.Increment();
                   }
               }
               else
               {
                   _sec.Increment();
               }
            
        }
        public void ClockTime()
        {
            Console.WriteLine($"{_hr.Ticks:00}:{_min.Ticks:00}:{_sec.Ticks:00}");

        } 
        public string Time
        {
            get
            {
                return $"{_hr.Ticks:00}:{_min.Ticks:00}:{_sec.Ticks:00}";
            }
        }

        public void ClockReset()
        {
            _sec.Reset();
            _min.Reset();
            _hr.Reset();
        }
    }
}
