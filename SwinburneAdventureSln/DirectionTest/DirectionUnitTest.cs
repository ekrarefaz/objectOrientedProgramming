using NUnit.Framework;
using SwinburneAdventure;

namespace DirectionTest
{
    public class Tests
    {
        Player newPlayer;
        Direction direct;

        Location locationHouse;
        Location locationForest;

        Item sword ;
        Item fireball ;               
        Item map  ;

        Bag playerBag ;
        Item healthpotion;


        [SetUp]
        public void Setup()
        {
            direct = new Direction();

            locationHouse = new Location("house", "Inside the tree house", new string[] { "through the door", "house" });
            locationForest = new Location("forest", "Surrounded by dense darkness", new string[] { "through a dark cluster of trees", "forest" });
            sword = new Item(new string[] { "bronze", "sword" }, "a sword", "mighty one");
            fireball = new Item(new string[] { "blazing", "fireball" }, "a fireball", "hot one");
            map = new Item(new string[] { "big", "map" }, "a map", "crazy one");

            newPlayer = new Player("longbeardmike", "A mighty unholy hero with legendary staff made of beard");


            playerBag = new Bag(new string[] { "bag", "rucksack" }, "Fjallraven", "A swedish Bag made to last");
            healthpotion = new Item(new string[] { "potion", "regenerate" }, "elixir", "regenerates health by 50 points");

            newPlayer.Location = locationForest;

            locationForest.Inventory.Put(map);

            //newPlayer.Inventory.Put(sword);
            newPlayer.Inventory.Put(playerBag);
            playerBag.Inventory.Put(sword);
            newPlayer.Inventory.Put(healthpotion);
        }

        [Test]
        public void ItemNotInLocationTest()
        {
            
            Assert.AreEqual("There is no fireball in forest", direct.Execute(newPlayer, "Take fireball".Split()));
        }
        [Test]
        public void TakeItemInLocationTest()
        {
            Assert.AreEqual("You have taken a map from forest", direct.Execute(newPlayer, "Take map".Split()));
        }
        [Test]
        public void PutItemInBagTest()
        {
            direct.Execute(newPlayer, "take map".Split());
            Assert.AreEqual("You put a map in Fjallraven", direct.Execute(newPlayer, "put map in bag".Split()));
        }
        [Test]
        public void PutItemInWrongPlaceTest()
        {
            Assert.AreEqual("Don't know where to put it", direct.Execute(newPlayer, "put map in pocket".Split()));
        }
        [Test]
        public void TakeItemFromInventoryTest()
        {

            Assert.AreEqual("You have taken elixir from Inventory", direct.Execute(newPlayer, "take potion".Split()));
        }
        [Test]
        public void TakeItemFromBagTest()
        {
            Assert.AreEqual("You have taken a sword from Fjallraven", direct.Execute(newPlayer, "take sword from bag".Split()));
        }
    }
}
