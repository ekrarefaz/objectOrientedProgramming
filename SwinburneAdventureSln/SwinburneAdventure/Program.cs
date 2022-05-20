using System;
using System.Linq;
namespace SwinburneAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commandInput = new string[] { "" };
            LookupCommand look = new LookupCommand();
            Console.WriteLine("Enter Player Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Player Description: ");
            string description = Console.ReadLine();

            Player newPlayer = new Player(name, description);

            Item sword = new Item(new string[] { "bronze", "sword" }, "a sword", "mighty one");
            Item fireball = new Item(new string[] { "blazing", "fireball" }, "a fireball", "hot one");
            Item map = new Item(new string[] { "big", "map" }, "a map", "crazy one");

            Bag playerBag = new Bag(new string[] { "bag", "rucksack" }, "Fjallraven", "A swedish Bag made to last");
            Item healthpotion = new Item(new string[] { "potion", "regenerate" }, "elixir", "regenerates health by 50 points");

            Location north = new Location("starting point", "starting point surrounded by a dense forest", new string[] { "starting point"});
            newPlayer.Location = north;


            north.Inventory.Put(map);
            newPlayer.Inventory.Put(sword);
            newPlayer.Inventory.Put(fireball);
            newPlayer.Inventory.Put(playerBag);
            playerBag.Inventory.Put(healthpotion);
            Console.WriteLine($"__Aventure Game__\ntype your command or exit to end game...");
            Console.WriteLine($"{newPlayer.FullDescription}\n");

            do
            {
                Console.WriteLine("Command>");
                commandInput = Console.ReadLine().Split();
                Console.WriteLine(look.Execute(newPlayer,commandInput));
            } while (commandInput[0] != "exit");



        }
    }
}
