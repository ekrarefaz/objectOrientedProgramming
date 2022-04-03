using SwinAdventure;
using NUnit.Framework;
using static SwinAdventure.IdentifiableObject;

namespace IdentifiableObjectTests
{
    public class Tests
    {
        private id IdentObj;
        string[] identities = new[] { "fred", "mike" };

        [SetUp]
        public void Setup()
        {
            IdentObj = new id(identities);
        }
        [Test]
        public void Test1()
        {
            Assert.True(IdentObj.AreYou(id: "mike"));
        }
        [Test]
        public void Test2()
        {
            Assert.False(IdentObj.AreYou(id: "sam"));
        }
        [Test]
        public void Test3()
        {
            Assert.True(IdentObj.AreYou(id: "FRED"));
        }
        [Test]
        public void Test4()
        {
            Assert.AreEqual("fred", IdentObj.FirstId());
        }
        [Test]
        public void Test5()
        {
            IdentObj.AddIdentifier("snowden");
            Assert.True(IdentObj.AreYou("snowden"));
        }
    }
}
