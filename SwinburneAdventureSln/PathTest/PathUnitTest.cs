using NUnit.Framework;
using SwinburneAdventure;
namespace PathTest
{
    public class Tests
    {
        Player newPlayer;
        Location locationHouse;
        Location locationForest;
        Path housePath;
        MoveCommand move;
        [SetUp]
        public void Setup()
        {
            move = new MoveCommand();
            locationHouse = new Location("house", "Inside the tree house", new string[] { "room", "house" });
            locationForest = new Location("forest", "Surrounded by dense darkness", new string[] { "forest" });
            housePath = new Path(locationHouse.Name, locationHouse.FullDescription, new string[] { "house" }, locationHouse);
            newPlayer = new Player("longbeardmike", "A mighty unholy hero with legendary staff made of beard");
            locationForest.AddPath(housePath);
            newPlayer.Location = locationForest;
        }
        [Test]
        public void PathDescriptionTest()
        {
            Assert.AreEqual("Inside the tree house", housePath.FullDescription);
        }
        [Test]
        public void PathHasLocationTest()
        {
            Assert.AreEqual(locationHouse, housePath.Location);
        }
        [Test]
        public void ValidIdentifierPathMoveTest()
        {

            move.Execute(newPlayer, "move house".Split());
            Assert.AreEqual(newPlayer.Location, locationHouse);
        }
        [Test]
        public void InvalidIdentifierPathMoveTest()
        {

            move.Execute(newPlayer, "move north".Split());
            Assert.AreEqual(newPlayer.Location, locationForest);
        }

    }
}
