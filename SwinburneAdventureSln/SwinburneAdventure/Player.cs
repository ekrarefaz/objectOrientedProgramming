using System;
namespace SwinburneAdventure
{
    public class Player : GameObject
    {
        private Inventory _inventory;
        public Player(string name, string des) : base(name, des, new[] { "me", "inventory"})
        {
            _inventory = new Inventory();
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;
            return Inventory.Fetch(id);
        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        public override string FullDescription
        {
            get
            {
                return $"You are {Name} the unholy programmer\n You have {Inventory.ItemList}";
            }
        }
    }
}
