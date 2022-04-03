using System;
namespace task2._1
{
    public class Counter
    {
        private int _count;
        private string _name;


        public Counter(string name)
        {
            this._name = name;
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

        public void PrintName()
        {
            Console.WriteLine("{0}", this._name);
        }

        public string Name
        {
            set { _name = value;  }
            get { return _name; }
        }

        public int Ticks
        {
            get { return _count; }
        }



        




    }
}
