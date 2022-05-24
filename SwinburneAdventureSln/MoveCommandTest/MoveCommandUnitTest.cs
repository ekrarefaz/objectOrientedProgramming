using NUnit.Framework;
using SwinburneAdventure;
namespace MoveCommandTest
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
        public void PathDoesNotExistTest()
        {
            string result = move.Execute(newPlayer, "move north".Split());
            Assert.AreEqual("404 Path Not Found", result);
        }
        [Test]
        public void WrongMoveCommandTest()
        {
            string result = move.Execute(newPlayer, "move".Split());
            Assert.AreEqual("I don't know how to move like that", result);

        }
        [Test]
        public void MovePlayerTest()
        {
            string result = move.Execute(newPlayer, "move house".Split()); ;
            Assert.AreEqual(locationHouse, newPlayer.Location);
        }
    }
}
