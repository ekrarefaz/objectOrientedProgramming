using NUnit.Framework;
using SwinburneAdventure;

namespace InventoryTest
{
    public class Tests
    {
        Inventory gameInventory = new Inventory();
        Item sword = new Item(new string[] { "bronze", "sword" }, "a sword", "might one");
        Item map = new Item(new string[] { "big", "map" }, "a map", "crazy one");
        Item fireball = new Item(new string[] { "blazing", "fireball" }, "a fireball", "hot one");

        [SetUp]
        public void Setup()
        {
            if(gameInventory.HasItem("sword"))
            {
                gameInventory.Take("sword");
            }
            if (gameInventory.HasItem("fireball"))
            {
                gameInventory.Take("fireball");
            }
            if (gameInventory.HasItem("map"))
            {
                gameInventory.Take("map");
            }
        }
        [Test]
        public void TestFindItem()
        {
            gameInventory.Put(sword);
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
            gameInventory.Put(sword);
            Assert.AreSame(sword, gameInventory.Fetch("sword"));
            gameInventory.Take("sword");
        }
        [Test]
        public void TestTakeItem()
        {
            gameInventory.Put(sword);
            Assert.AreSame(sword, gameInventory.Take("sword"));
            gameInventory.Put(map);
            gameInventory.Take("map");
            Assert.False(gameInventory.HasItem("map"));
        }
        [Test]
        public void TestItemList()
        {
            gameInventory.Put(sword);
            gameInventory.Put(fireball);
            string toMatch = "\ta sword (bronze)\n\ta fireball (blazing)\n";
            Assert.AreEqual(toMatch, gameInventory.ItemList);
        }
    }
}
