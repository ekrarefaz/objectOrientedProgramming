using System;
using System.Linq;
namespace SwinburneAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commandInput = new string[] { "" };
            CommandProcessor command = new CommandProcessor();
            Console.WriteLine("Enter Player Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Player Description: ");
            string description = Console.ReadLine();

            Player newPlayer = new Player(name, description);

            Location start = new Location("starting point", "starting point", new string[] { "from the tunnel", "start" });
            Location locationHouse = new Location("house", "Inside the tree house", new string[] { "through the door", "house" });
            Location locationForest = new Location("forest", "Surrounded by dense darkness", new string[] { "through a dark cluster of trees", "forest" });
            Path housePath = new Path(locationHouse.Name, locationHouse.FullDescription, new string[] { "house" }, locationHouse);
            Path forestPath = new Path(locationForest.Name, locationForest.FullDescription, new string[] { "forest" }, locationForest);
            Item sword = new Item(new string[] { "bronze", "sword" }, "a sword", "mighty one");
            Item fireball = new Item(new string[] { "blazing", "fireball" }, "a fireball", "hot one");
            Item map = new Item(new string[] { "big", "map" }, "a map", "crazy one");

            Bag playerBag = new Bag(new string[] { "bag", "rucksack" }, "Fjallraven", "A swedish Bag made to last");
            Item healthpotion = new Item(new string[] { "potion", "regenerate" }, "elixir", "regenerates health by 50 points");

            newPlayer.Location = locationForest;
            start.AddPath(forestPath);
            locationForest.AddPath(housePath);
            locationHouse.AddPath(forestPath);

            locationHouse.Inventory.Put(fireball);
            locationForest.Inventory.Put(map);
            newPlayer.Inventory.Put(sword);
            newPlayer.Inventory.Put(playerBag);
            playerBag.Inventory.Put(healthpotion);
            Console.WriteLine($"__Aventure Game__\ntype your command or exit to end game...");
            Console.WriteLine($"{newPlayer.FullDescription}\n");

            do
            {
                Console.WriteLine("Command>");
                commandInput = Console.ReadLine().Split();
                Console.WriteLine(command.Execute(newPlayer,commandInput));
            } while (commandInput[0] != "exit");



        }
    }
}
