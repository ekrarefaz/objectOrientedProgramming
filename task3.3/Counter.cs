using System;
namespace Glock
{
    public class Counter
    {
        private int _count;
        public Counter()
        {      
            this._count = 0;
        }
        public void Increment()
        {
            this._count++;
        }
        public void Reset()
        {
            this._count = 0;
        }
        public int Ticks
        {
            get { return _count; }
        }
    }
}
