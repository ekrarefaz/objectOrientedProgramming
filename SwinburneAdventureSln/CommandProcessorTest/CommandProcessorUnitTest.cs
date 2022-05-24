using NUnit.Framework;
using SwinburneAdventure;
namespace CommandProcessorTest
{
    public class Tests
    {
        Player newPlayer;

        Location locationHouse;
        Location locationForest;
        Path housePath;

        Item sword;
        Item fireball;
        Item map;

        Bag playerBag;
        Item healthpotion;
        CommandProcessor command;
        
        [SetUp]
        public void Setup()
        {
            locationHouse = new Location("house", "Inside the tree house", new string[] { "through the door", "house" });
            locationForest = new Location("forest", "Surrounded by dense darkness", new string[] { "through a dark cluster of trees", "forest" });
            sword = new Item(new string[] { "bronze", "sword" }, "a sword", "mighty one");
            fireball = new Item(new string[] { "blazing", "fireball" }, "a fireball", "hot one");
            map = new Item(new string[] { "big", "map" }, "a map", "crazy one");

            newPlayer = new Player("longbeardmike", "A mighty unholy hero with legendary staff made of beard");


            playerBag = new Bag(new string[] { "bag", "rucksack" }, "Fjallraven", "A swedish Bag made to last");
            healthpotion = new Item(new string[] { "potion", "regenerate" }, "elixir", "regenerates health by 50 points");

            newPlayer.Location = locationForest;
            housePath = new Path(locationHouse.Name, locationHouse.FullDescription, new string[] { "house" }, locationHouse);
            locationForest.AddPath(housePath);
            locationForest.Inventory.Put(map);

            //newPlayer.Inventory.Put(sword);
            newPlayer.Inventory.Put(playerBag);
            newPlayer.Inventory.Put(sword);
            newPlayer.Inventory.Put(healthpotion);
            command = new CommandProcessor();
        }
        [Test]
        public void MoveCommandTest()
        {
            command.Execute(newPlayer, "move house".Split());
            Assert.AreEqual(newPlayer.Location, locationHouse);

        }
        [Test]
        public void LookUpCommandTest()
        {
            Assert.AreEqual("mighty one",command.Execute(newPlayer, "look at sword".Split()));
            
        }
        [Test]
        public void Direction()
        {
            Assert.AreEqual("You have taken a map from forest", command.Execute(newPlayer, "Take map".Split()));

        }
    }
}
