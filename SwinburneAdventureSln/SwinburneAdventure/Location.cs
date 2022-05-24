using System;
using System.Collections.Generic;
namespace SwinburneAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths;
        public Location(string name, string description, string[] ids) : base(name, description, ids)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }
        public GameObject Locate(string id)
        {
            if(AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        public bool HasPath(string id)
        {
            foreach (Path path in _paths)
            {
                if (path.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }
        public Path ReturnPath(string id)
        {
            foreach (Path path in _paths)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }
            return null;
        }
        public void AddPath(Path path)
        {
            _paths.Add(path);
        }
        public string PathList
        {
            get
            {
                string list = "";
                foreach (Path path in _paths)
                {
                    list += path.ShortDescription + "\n";
                }
                return list;
            }
        }
    }
}
