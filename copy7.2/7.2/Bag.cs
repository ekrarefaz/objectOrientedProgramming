using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2

{

    public class Bag : Item, IHaveInventory
    {
        private Inventory _invntry;

        public Bag(string[] ids, string name, string excp) : base(ids, name, excp)
        {
            _invntry = new Inventory();
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

        public Inventory Inventory
        {
            get => _invntry;
        }

        public override string FullExplaination
        {
            get
            {
                string bagItems = "In the " + this.FirstId + " you can see:" + "\n" + Inventory.ItemList;
                return bagItems;
            }
        }
   
    }
}
