using System;
using System.Collections.Generic;
namespace _7._2
{
    public class Location : Item, IHaveInventory
    {
        private Inventory _invntry;
        private List<Path> _path;
        public Location(string[] ids, string name, string excp) : base(ids, name, excp)
        {
            _invntry = new Inventory();
            _path = new List<Path>();
        }

        public Inventory Inventory
        {
            get => _invntry;
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }

            else if (this._invntry.HasItem(id))
            {
                return this._invntry.Fetch(id);
            }

            return null;
        }

        public bool hasPath(string ids)
        {
            foreach (Path player1 in _path)
            {
                if (player1.AreYou(ids) == true)
                {
                    return true;
                }
            }
            return false;
        }
        public void addPath(Path paths)
        {
            _path.Add(paths);
        }
        public string pathExcp(Path player1, string id)
        {
            if (player1.AreYou(id))
            {
                return player1.FullExplaination;
            }
            else
            {
                return "error in loc pathExcp";
            }
        }
        public Path returnPath(string oo)
        {
            foreach (Path x in _path)
            {
                if (x.AreYou(oo))
                {
                    return x;
                }
            }
            return null;
        }

        public override string FullExplaination
        {
            get
            {
                return "In this location:\n " + this.Name + " you can see" + "\n" + _invntry.ItemList;
            }
        }
        public List<Path> path
        {
            get => _path;
        }
    }
}
