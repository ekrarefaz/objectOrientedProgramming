using System;
namespace SwinburneAdventure
{
    public class Bag : Item
    {
        private Inventory _inventory;
        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {

            if (AreYou(id))
                return this;
            return Inventory.Fetch(id);

        }
        public override string FullDescription
        {
            get
            {
                return $"This is the {this.Name}, Showing Items: {Inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

    }
}
