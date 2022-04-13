using NUnit.Framework;
using SwinburneAdventure;

namespace PlayerTest
{
    public class Tests
    {
        Player newPlayer;
        Inventory gameInventory;
        Item Sword;
        Item Map;

        [SetUp]
        public void Setup()
        {
            newPlayer = new Player("longbeardmike", "A mighty unholy hero with legendary staff made of beard");
            gameInventory = new Inventory();
            Sword = new Item(new string[] { "bronze", "sword" }, "a sword", "might one");
            Map = new Item(new string[] { "big", "map" }, "a map", "crazy one");

            newPlayer.Inventory.Put(Sword);
        }
        [Test]
        public void PlayerIdentifyTest()
        {
            Assert.True(newPlayer.AreYou("me"));
            Assert.True(newPlayer.AreYou("inventory"));
        }
        [Test]
        public void PlayerLocateItemsTest()
        {
            Assert.AreSame(Sword, newPlayer.Locate("sword"));
        }
        [Test]
        public void PlayerLocateItselfTest()
        {
            Assert.AreSame(newPlayer, newPlayer.Locate("me"));
            Assert.AreSame(newPlayer, newPlayer.Locate("inventory"));
        }
        [Test]
        public void PlayerLocatesNothing()
        {
            Assert.AreSame(null, newPlayer.Locate("car"));
        }
        [Test]
        public void PlayerDescriptionTest()
        {
            string result = $"You are {newPlayer.Name} the unholy programmer\n You have {newPlayer.Inventory.ItemList}";
            Assert.AreEqual(result, newPlayer.FullDescription);
        }
    }
}
