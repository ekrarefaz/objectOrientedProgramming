using System;
namespace ClockTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            while (true)
            {
                clock.TrackTicks();
                clock.ClockTime();
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
