using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        private IHaveInventory FetchContainer(Player player1, string containerId)
        {
            return player1.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)

        {
            GameObject item = container.Locate(thingId);
            if (item == null)
            {
                return ("I can't find the " + thingId);
            }
            return item.FullExplaination;
        }

        public override string Execute(Player player1, string[] text)
        {
            IHaveInventory container = null;
            string containerTxt;
            if (text.Length != 3 && text.Length != 5)
                return "I don’t know how to look like that";
            if (text[0] != "look")
                return "Error in look input";
            if (text[1] != "at")
                return "What do you want to look at?";
            string itemTxt = text[2];
            if (text.Length == 5)
            {
                if (text[3] != "in")
                    return "What do you want to look in?";
                containerTxt = text[4];
                container = FetchContainer(player1, containerTxt);
                if (container == null)
                {
                    return "I can't find the " + containerTxt;
                }
                return LookAtIn(itemTxt, container);

            }
            else if (text.Length == 3)
            {
                container = player1;
            }

            return LookAtIn(itemTxt, container);
        }

       
    }
}


