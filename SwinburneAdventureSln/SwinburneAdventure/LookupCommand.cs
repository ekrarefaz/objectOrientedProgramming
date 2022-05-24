using System;
using System.Collections.Generic;
using System.Linq;
namespace SwinburneAdventure
{
    public class LookupCommand : Command
    {
        public LookupCommand() : base(new string[] { "look" })
        {

        }
        public override string Execute(Player p, string[] text)
        {
            IHaveInventory itemContainer;
            if (text.Length == 1 && text[0].ToLower() == "look")
            {
                return $"You are in {p.Location.FullDescription} and nearby you can see {p.Location.Inventory.ItemList} and way to {p.Location.PathList}";
            }
            else if (text.Length != 3 && text.Length != 5)
            {
                return "I dont know how to look like that";
            }
            else
            {
                if (text[0].ToLower() != "look")
                {
                    return "Error in Look input\n";
                }
                if (text[1].ToLower() != "at")
                {
                    return "what do you wanna look at?";
                }
                if (text.Length == 5 && text[3].ToLower() != "in")
                {
                    return "what do you want to look in?";
                }
                if (text.Length == 3)
                {
                    string itemName = text[2].ToLower();
                    itemContainer = p as IHaveInventory;
                    return LookAtIn(itemName, itemContainer);
                }
                if (text.Length == 5)
                {
                    string itemToFind = text[2];
                    string containerName = text[4];
                    IHaveInventory container = FetchContainer(p, containerName);
                    if (container is null)
                    {
                        return $"I cannot find the {containerName}\n";
                    }
                    return LookAtIn(itemToFind, container);
                }
            }
            return "Executed";
        }
        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string itemId, IHaveInventory container)
        {
            if (container.Locate(itemId) != null)
            {
                var item = container.Locate(itemId);
                return item.FullDescription;
            }
            else
            {
                return $"I can't find the {itemId}";
            }
        }
    }
}
