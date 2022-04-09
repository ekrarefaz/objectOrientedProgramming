using NUnit.Framework;
using SwinburneAdventure;

namespace InventoryTest
{
    public class Tests
    {
        Inventory gameInventory = new Inventory();
        Item Sword = new Item(new string[] { "bronze", "sword" }, "a sword", "might one");
        Item Map = new Item(new string[] { "big", "map" }, "a map", "crazy one");
        Item Fireball = new Item(new string[] { "blazing", "fireball" }, "a fireball", "hot one");

        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void TestFindItem()
        {
            gameInventory.Put(Sword);
            Assert.True(gameInventory.HasItem("sword"));
        }
        [Test]
        public void TestNoItem()
        {
            Assert.False(gameInventory.HasItem("map"));
        }
        [Test]
        public void TestFetchItem()
        {
            gameInventory.Put(Sword);
            Assert.AreSame(Sword, gameInventory.Fetch("sword"));
            gameInventory.Take("sword");
        }
        [Test]
        public void TestTakeItem()
        {
            Assert.AreSame(Sword, gameInventory.Take("sword"));
            gameInventory.Put(Map);
            gameInventory.Take("map");
            Assert.False(gameInventory.HasItem("map"));
        }
        [Test]
        public void TestItemList()
        {
            gameInventory.Put(Fireball);
            string toMatch = "a sword (bronze)a fireball (blazing)";
            Assert.AreEqual(toMatch, gameInventory.ItemList);


        }
    }
}
