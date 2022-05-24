using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2
{
    public class Inventory
    {
        private List<Item> _itms;

        public Inventory()
        {
            _itms = new List<Item>();
        }

        public void Put(Item item)
        {
            _itms.Add(item);
        }


        public bool HasItem(string id)
        {
            foreach (Item i in _itms)
            {
                if (i.AreYou(id) == true)
                {
                    return true;
                }

            }

            return false;
        }

        public Item Fetch(string id)
        {
            foreach (Item i in _itms)
            {
                if (i.AreYou(id) == true)
                {
                    return i;
                }
            }

            return null;
        }


        public Item Take(string id)
        {
            foreach (Item i in _itms)
            {
                if (i.AreYou(id) == true)
                {
                    _itms.Remove(i);
                }
                return i;
            }
            return null;
        }

       
        public string ItemList
        {
            get
            {
                foreach (Item i in _itms)
                {
                    string list = i.Name + "\t" + i.ShortExplaination + "\n";
                    return list;
                }
                return null;
            }
        }
    }
}
