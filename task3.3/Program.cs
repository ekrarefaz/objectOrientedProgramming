using System;
namespace Glock
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            while (true)
            {
                clock.TrackTime();
                clock.ClockTime();
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
