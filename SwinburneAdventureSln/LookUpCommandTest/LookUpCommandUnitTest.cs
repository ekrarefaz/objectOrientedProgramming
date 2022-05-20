using NUnit.Framework;
using SwinburneAdventure;

namespace LookUpCommandTest
{
    public class Tests
    {
        private LookupCommand _look = new LookupCommand();
        private Player _newPlayer;
        private Bag _newBag;
        private Item _sword;
        private Item _gem;
        [SetUp]
        public void Setup()
        {

            _newPlayer = new Player("longbeardmike", "A mighty unholy hero with legendary staff made of beard");

            _newBag = new Bag(new string[] { "bag", "rucksack" }, "Fjallraven", "A swedish Bag made to last");
            _sword = new Item(new string[] { "bronze", "sword" }, "a sword", "mighty one");
            _gem = new Item(new string[] { "blazing", "gem" }, "a fireball", "hot one");

        }

        [Test]
        public void TestLookAtMe()
        {
            _newPlayer.Inventory.Put(_sword);
            string result = $"You are longbeardmike A mighty unholy hero with legendary staff made of beard\nYou have \ta sword (bronze)\n";
            string[] input = new[] {"look",  "at",  "inventory"};
            Assert.AreEqual(result, _look.Execute(_newPlayer,input));
            
        }

        [Test]
        public void TestLookAtGem()
        {
            _newPlayer.Inventory.Put(_gem);
            string result = $"hot one";
            string[] input = new[] { "look",  "at",  "gem"};
            Assert.AreEqual(result, _look.Execute(_newPlayer, input));
        }

        [Test]
        public void TestLookAtUnk()
        {
            string result = $"hot one";
            string[] input = new[] { "look", "at", "gem" };
            Assert.AreEqual("I can't find the gem", _look.Execute(_newPlayer, input));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            _newPlayer.Inventory.Put(_sword);
            string result = $"mighty one";
            string[] input = new[] { "look", "at", "sword", "in", "me" };
            Assert.AreEqual(result, _look.Execute(_newPlayer, input));
        }
        [Test]
        public void TestLookAtGemInBag()
        {
            _newPlayer.Inventory.Put(_newBag);
            _newBag.Inventory.Put(_sword);
            string result = $"mighty one";
            string[] input = new[] { "look", "at", "sword", "in", "bag" };
            Assert.AreEqual(result, _look.Execute(_newPlayer, input));
        }
        [Test]
        public void TestLookAtGemInNoBag()
        {
            string result = $"I cannot find the bag\n";
            string[] input = new[] { "look", "at", "sword", "in", "bag" };
            Assert.AreEqual(result, _look.Execute(_newPlayer, input));
        }
        [Test]
        public void TestLookAtNoGemInBag()
        {
            _newPlayer.Inventory.Put(_newBag);
            _newBag.Inventory.Put(_sword);
            string result = $"I can't find the gem";
            string[] input = new[] { "look", "at", "gem", "in", "bag" };
            Assert.AreEqual(result, _look.Execute(_newPlayer, input));
        }
        [Test]
        public void TestInvalidLook()
        {
            Assert.AreEqual("I dont know how to look like that", _look.Execute(_newPlayer, new[] { "hello" }));
            Assert.AreEqual("Error in Look input\n", _look.Execute(_newPlayer, new[] { "hello", "at", "gem"}));
            Assert.AreEqual("what do you wanna look at?", _look.Execute(_newPlayer, new[] { "look", "world", "gem" }));
            Assert.AreEqual("what do you want to look in?", _look.Execute(_newPlayer, new[] { "look", "at", "gem", "inside", "bag" }));

        }

    }
}
