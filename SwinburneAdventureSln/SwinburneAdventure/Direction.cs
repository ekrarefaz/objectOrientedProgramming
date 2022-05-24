using System;
namespace SwinburneAdventure
{
    public class Direction : Command
    {

        public Direction() : base(new string[] { "put" , "take"})
        {
        }

        public override string Execute(Player p, string[] text)
        {
            Location currentLocation = p.Location;
            Item item;
            if (text[0].ToLower()=="take" && text.Length == 2)
            {
                if(currentLocation.Inventory.HasItem(text[1]))
                {
                    item = currentLocation.Inventory.Take(text[1]);
                    p.Inventory.Put(item);
                    return $"You have taken {item.Name} from {currentLocation.Name}";
                }
                else if(p.Inventory.HasItem(text[1]))
                {
                    item = p.Inventory.Take(text[1]);
                    return $"You have taken {item.Name} from Inventory";
                }
                return $"There is no {text[1]} in {currentLocation.Name}";
            }
            else if(text[0].ToLower() == "take" && text.Length == 4)
            {
                if (!p.Inventory.HasItem(text[1]))
                {
                    if (p.Inventory.HasItem(text[3]))
                    {
                        Bag bag = FetchBag(p, text[3]);
                        item = bag.Inventory.Take(text[1]);
                        return $"You have taken {item.Name} from {bag.Name}";
                    }
                    return $"Can't find the bag";
                }
                return $"You're looking in the wrong place";
            }
            else if (text[0].ToLower() == "put" && text.Length == 4)
            {
                item = p.Inventory.Take(text[1]);
                if (text[3].ToLower() == currentLocation.Name.ToLower())
                {
                    currentLocation.Inventory.Put(item);
                }
                else
                {
                    Bag bag = FetchBag(p, text[3]);
                    if(bag != null)
                    {
                        bag.Inventory.Put(item);
                        return $"You put {item.Name} in {bag.Name}";
                    }
                    return $"Don't know where to put it";
                }     
            }
            return $"Wrong Command";
        }

        public Bag FetchBag(Player p, string containerId)
        {
            return p.Locate(containerId) as Bag;
        }
    }
}
