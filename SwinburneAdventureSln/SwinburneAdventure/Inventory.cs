using System;
using System.Collections.Generic;
namespace SwinburneAdventure
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public Inventory()
        {

        }
        public bool HasItem(string id)
        {
            foreach(Item item in _items)
            {
                if(item.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }
        public void Put(Item item)
        {
            _items.Add(item);
        }
        public Item Take(string id)
        {
            Item item = Fetch(id);
            _items.Remove(item);
            return item;
        }
        public Item Fetch(string id)
        {
            foreach(Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }
        public string ItemList
        {
            get
            {
                string list = "";
                foreach(Item item in _items)
                {
                    list += "\t"+item.ShortDescription +"\n";
                }
                return list;
            }
        }
    }
}
