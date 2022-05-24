using NUnit.Framework;
using _7._2;

namespace TestPath
{
    [TestFixture()]
    public class PathTest
    {

        [Test()]
        public void get_Path_from_identifier()
        {
            Location loctn2 = new Location(new string[] { "room2" }, "room2", "a big room");
            Path _path = new Path(new string[] { loctn2.FirstId }, loctn2.Name, "through the door", loctn2);
            string s = loctn2.pathExcp(_path, _path.Name);
            string l = "through the door";
            Assert.AreEqual(s, l);
        }


        [Test()]
        public void testPathMovePlayer_with_valid_identifier()
        {
            Location loctn1 = new Location(new string[] { "room1" }, "room1", "a dark room!");
            Location loctn2 = new Location(new string[] { "room2" }, "room2", "a big room");
            Path _path = new Path(new string[] { "room2" }, loctn2.Name, "through the door", loctn2);
            Player player11 = new Player("boy", "strong boy", loctn1);
            Assert.IsTrue(player11.location.Name == "room1");
            loctn1.path.Add(_path);
            MoveCommand _move = new MoveCommand();
            string s = "move room2";
            _move.Execute(player11, s.Split());
            Assert.AreEqual(player11.location.Name, loctn2.Name);
        }

        [Test()]
        public void testPathMovePlayer_with_invalid_identifire()
        {
            Location loctn1 = new Location(new string[] { "room1" }, "room1", "a dark room!");
            Location loctn2 = new Location(new string[] { "room2" }, "room2", "a big room");
            Path _path = new Path(new string[] { "room2" }, loctn2.Name, "through the door", loctn2);
            Player player11 = new Player("boy", "strong boy", loctn1);
            Assert.IsTrue(player11.location.Name == "room1");
            loctn1.path.Add(_path);
            MoveCommand _move = new MoveCommand();
            string s = "move room4";
            _move.Execute(player11, s.Split());
            Assert.AreEqual(player11.location.Name, loctn1.Name);
        }

    }
}
