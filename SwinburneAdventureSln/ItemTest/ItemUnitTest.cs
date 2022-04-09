using NUnit.Framework;
using SwinburneAdventure;

namespace ItemTest
{
    public class Tests
    {
        public Item gameItem;
        [SetUp]
        public void Setup()
        {
            gameItem = new Item(new string[] {"bronze", "sword"}, "a sword", "A holy shovel that cannot be weilded by the unholy hero");
        }

        [Test]
        public void AreYouTest()
        {
            Assert.True(gameItem.AreYou("sword"));
        }
        [Test]
        public void ShortDescriptionTest()
        {
            Assert.AreEqual("a sword (bronze)", gameItem.ShortDescription);
        }
        [Test]
        public void NotYouTest()
        {
            Assert.False(gameItem.AreYou("bazooka"));
        }
        [Test]
        public void FullDescriptionTest()
        {
            Assert.AreEqual("A holy shovel that cannot be weilded by the unholy hero", gameItem.FullDescription);
        }
    }
}
