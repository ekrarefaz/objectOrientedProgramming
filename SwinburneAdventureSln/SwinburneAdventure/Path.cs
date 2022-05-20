using System;
namespace SwinburneAdventure
{
    public class Path : GameObject
    {
        private Location _location;

        public Path(string name, string description, string[] ids, Location location) : base(name, description, ids)
        {

        }
        public Location Location
        {
            get
            {
                return _location;
            }
        }
    }
}
