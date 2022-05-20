using NUnit.Framework;
using SwinburneAdventure;

namespace LocationTest
{
    public class Tests
    {
        Location newLocation;
        Player newPlayer;
        Item sword;
        Item map;
        [SetUp]
        public void Setup()
        {
            newPlayer = new Player("longbeardmike", "A mighty unholy hero with legendary staff made of beard");
            sword = new Item(new string[] { "bronze", "sword" }, "a sword", "mighty one");
            map = new Item(new string[] { "big", "map" }, "a map", "crazy one");
            newLocation = new Location("South", "South of the Player", new string[] { "south"});
            newLocation.Inventory.Put(sword);
            newLocation.Inventory.Put(map);
        }
        [Test]
        public void LocationIdentifyTest()
        {
            Assert.True(newLocation.AreYou("south"));
        }
        [Test]
        public void LocationLocateItemTest()
        {
            newLocation.Inventory.Put(sword);
            Assert.AreSame(newLocation.Locate("sword"), sword);
        }
        [Test]
        public void PlayerLocatesItemsInLocationTest()
        {
            newPlayer.Location = newLocation;
            newLocation.Inventory.Put(sword);
            Assert.AreSame(newPlayer.Locate("sword"), sword);
        }
        [Test]
        public void PlayerInLocationTest()
        {
            newPlayer.Location = newLocation;
            Assert.AreSame(newLocation, newPlayer.Location);
        }
    }
}
