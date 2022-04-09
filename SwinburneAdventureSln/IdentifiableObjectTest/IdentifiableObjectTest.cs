
using NUnit.Framework;
using SwinburneAdventure;
 
namespace IdentifiableObjectTests
{
    public class Tests
    {
        private IdentifiableObject IdentifiableObject;
        string[] identities = new[] { "fred", "mike" };

        [SetUp]
        public void Setup()
        {
            IdentifiableObject = new IdentifiableObject(identities);
        }
        [Test]
        public void TestAreYou()
        {
            Assert.True(IdentifiableObject.AreYou(id: "mike"));
        }
        [Test]
        public void TestYouAreNot()
        {
            Assert.False(IdentifiableObject.AreYou(id: "sam"));
        }
        [Test]
        public void TestCaseSensitive()
        {
            Assert.True(IdentifiableObject.AreYou(id: "FRED"));
            Assert.True(IdentifiableObject.AreYou(id: "fReD"));
            Assert.True(IdentifiableObject.AreYou(id: "freD"));

        }
        [Test]
        public void TestFirstId()
        {
            Assert.AreEqual("fred", IdentifiableObject.FirstId);
        }
        [Test]
        public void TestAddIt()
        {
            IdentifiableObject.AddIdentifier("snowden");
            Assert.True(IdentifiableObject.AreYou("snowden"));
            Assert.True(IdentifiableObject.AreYou("fred"));
            Assert.True(IdentifiableObject.AreYou("mike"));
        }
    }
}
