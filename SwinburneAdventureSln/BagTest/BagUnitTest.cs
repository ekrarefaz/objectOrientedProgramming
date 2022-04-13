using NUnit.Framework;
using SwinburneAdventure;

namespace BagTest
{

    public class Tests
    {
        Bag playerBag = new Bag(new string[] { "bag", "rucksack" }, "Fjallraven", "A swedish Bag made to last");
        Bag smallPurse = new Bag(new string[] { "small bag", "purse" }, "Gucci", "Unnecessary Bag for status symbol");
        Inventory bagInventory = new Inventory();
        Item Sword = new Item(new string[] {"bronze", "sword"}, "a sword", "A holy shovel that cannot be weilded by the unholy hero");
        Item Map = new Item(new string[] { "big", "map" }, "a map", "crazy one");
        Item Fireball = new Item(new string[] { "blazing", "fireball" }, "a fireball", "hot one");
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void BagLocatesTest()
        {
            playerBag.Inventory.Put(Sword);

            playerBag.Inventory.Put(smallPurse);

            playerBag.Inventory.Put(Map);

            Assert.AreEqual(Sword, playerBag.Locate("sword"));
            Assert.AreEqual(Map, playerBag.Locate("map"));
        }
        [Test]
        public void BagLocatesItselfTest()
        {
            Assert.AreEqual(playerBag, playerBag.Locate("rucksack"));
        }
        [Test]
        public void BagLocatesNothingTest()
        {
            playerBag.Inventory.Put(Sword);

            playerBag.Inventory.Put(Map);

            Assert.AreEqual(null, playerBag.Locate("ferrari"));
        }
        [Test]
        public void BagFullDesTest()
        {
            playerBag.Inventory.Put(Sword);

            playerBag.Inventory.Put(Map);

            string result = $"This is the Fjallraven, Showing Items: {playerBag.Inventory.ItemList}";
            Assert.AreEqual(result,playerBag.FullDescription);
        }
        [Test]
        public void BagInBagTest()
        {
            playerBag.Inventory.Put(Sword);

            playerBag.Inventory.Put(smallPurse);

            smallPurse.Inventory.Put(Fireball);

            Assert.AreEqual(smallPurse, playerBag.Locate("purse"));
            Assert.AreEqual(Sword, playerBag.Locate("sword"));
            Assert.AreNotEqual(Fireball, playerBag.Locate("fireball"));
        }
    }
}
