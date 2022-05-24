using System;
using System.Collections.Generic;

namespace _7._2
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _invntry;
        private Location _place;
        public Player(string name, string excp, Location loctn) : base(new string[] { "me", "inventory" }, name, excp)
        {
            _invntry = new Inventory();
            _place = loctn;
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

       
        public Location location
        {
            get
            {
                return _place;
            }
            set
            {
                _place = value;
            }
        }

        public override string FullExplaination
        {
            get
            {
                return "You are " + this.Name + "\n" + "You are carrying: " + "\n" + _invntry.ItemList;
            }
        }
    }
}
