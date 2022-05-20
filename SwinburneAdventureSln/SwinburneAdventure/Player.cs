using System;
namespace SwinburneAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;
        public Player(string name, string des) : base(name, des, new[] { "me", "inventory"})
        {
            _inventory = new Inventory();
        }
        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }

            if (_inventory.Fetch(id) != null)
            {
                return _inventory.Fetch(id);
            }
            if (_location != null)
            {
                return _location.Locate(id);
            }
            return null;
        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
        public override string FullDescription
        {
            get
            {
                return $"You are {Name} {base.FullDescription}\nLocation:\n{Location.FullDescription}\nYou have {Inventory.ItemList}";
            }
        }
    }
}
