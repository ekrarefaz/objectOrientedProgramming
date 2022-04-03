using System;

namespace HelloWorld
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Console.ReadLine();
            Message[] arrayMessages = new Message[4];
            string[] names = { "ekrar", "golam", "nihal", "azmain" };
            arrayMessages[0] = new Message("Ekrar Loves Mike's Thursday Lab");
            arrayMessages[1] = new Message("Golam also agrees Mike is an awesome Tutor");
            arrayMessages[2] = new Message("Nihal is sad that he didn't get assigned to Mike's Lab");
            arrayMessages[3] = new Message("Azmain doesn't know what is going on because he is a Windows user.");

            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            name = name.ToLower();

            if (name == "ekrar")
            {
                arrayMessages[0].Print();
            }
            else if (name == "golam")
            {
                arrayMessages[1].Print();
            }
            else if (name == "nihal")
            {
                arrayMessages[2].Print();
            }
            else if (name == "azmain")
            {
                arrayMessages[3].Print();
            }
            else
            {
                Console.WriteLine("Hey {0} are you even an OOP student?", name);
            }
        }
    }
}
