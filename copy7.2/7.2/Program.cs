using System;

namespace _7._2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
            Bag bg = new Bag(new string[] { "bag" }, "small bag", "a small bag made of leather!");

            Location south = new Location(new string[] { "south", "beach" }, "beach", "A huge windy beach ");
            Location north = new Location(new string[] { "north", "closet" }, "closet", "A small dark closet"); 
            Location west = new Location(new string[] { "west", "garden" }, "garden", "There are many beautiful flowers in this garden"); 
            Location east = new Location(new string[] { "east", "lab" }, "lab", "A room full of powerful computers");

            Path pth1 = new Path(new string[] { south.FirstId }, "south", "through the door", south);
            Path pth2 = new Path(new string[] { north.FirstId }, "north", "through the door", north);
            Path pth3 = new Path(new string[] { west.FirstId }, "west", "through the door", west);
            Path pth4 = new Path(new string[] { east.FirstId }, "east", "through the door", east);

            Item itm1 = new Item(new string[] { "shovel" }, "shovel", "a big shovel!");
            Item itm2 = new Item(new string[] { "spade" }, "spade", "a very powerfull spade!");
            Item itm3 = new Item(new string[] { "gem" }, "gem", "a very ordinary gem!");
            Item itm4 = new Item(new string[] { "stone" }, "stone", "a very heavy stone");
            Item itm5 = new Item(new string[] { "dagger" }, "apple", "a small dagger");
            Item itm6 = new Item(new string[] { "sword" }, "sword", "a sharp sword!");


            Player _player = new Player("boy", "strong boy", south);

            _player.Inventory.Put(itm1);

            _player.location.path.Add(pth1);
            _player.location.path.Add(pth2);
            _player.location.path.Add(pth3);
            _player.location.path.Add(pth4);

            south.Inventory.Put(itm2);
            north.Inventory.Put(itm3);
            west.Inventory.Put(itm4);
            east.Inventory.Put(itm5);
            bg.Inventory.Put(itm6);
            north.Inventory.Put(bg);

            CommandProcessor _comProcess = new CommandProcessor();
            bool _exit;
            _exit = false;
            while (_exit == false)
            {
                Console.WriteLine("\nEnter command:");
                string command = Console.ReadLine();

                if (command == "quit")
                {
                    _exit = true;

                }

                if (_exit == true)
                {
                    Console.WriteLine("\nGood Bye!");
                    Environment.Exit(0);
                }
                string res = _comProcess.Execute(_player, command.Split());
                Console.WriteLine("\n" + res);

            }
        }
    }
}
