using System;
using System.Collections.Generic;
namespace _7._2
{
    public class Direction : Command
    {
        public Direction() : base(new string[] { "put", "take" })
        {
        }

        public override string Execute(Player player1, string[] text)
        {
            
            if (text[0] == "take")
            {
                if (text.Length == 2)
                {
                    Location loct = player1.location;
                    if (loct.Inventory.HasItem(text[1]))
                    {
                        Item item = loct.Inventory.Fetch(text[1]);
                        player1.Inventory.Put(item);
                        loct.Inventory.Take(text[1]);
                        return "You have taken the " + item.Name + " from a "
                            + loct.Name;
                    }
                    else
                    {
                        return "Cannot find " + text[1] + " in " + loct.Name;
                    }
                }

                else if (text.Length == 4)
                {
                    Bag bg = FetchBag(player1, text[3]);
                    if (bg.Inventory.HasItem(text[1]))
                    {
                        Item item2 = bg.Inventory.Fetch(text[1]);
                        bg.Inventory.Take(text[1]);
                        player1.Inventory.Put(item2);
                        return "You have taken the " + item2.Name +
                            " from the " + bg.Name;
                    }
                    else
                    {
                        return "Cannot find " + text[1] + " in " + bg.Name;
                    }
                }
                else
                {
                    return "no luck !";
                }
            }
            else if (text[0] == "put")
            {
                if (text.Length == 4)
                {
                    if (player1.Inventory.HasItem(text[1]))
                    {
                        Item item3 = player1.Inventory.Fetch(text[1]);
                        if (text[3] == "bag")
                        {
                            Bag bg1 = (Bag)player1.Inventory.Fetch(text[3]);
                            bg1.Inventory.Put(item3);
                            player1.Inventory.Take(text[1]);
                            return "You have put the " + item3.Name + " in the " + bg1.Name;
                        }
                        else if (text[3] == player1.location.Name)
                        {
                            player1.location.Inventory.Put(item3);
                            player1.Inventory.Take(text[1]);
                            return "You have put the " + item3.Name + " in the " + player1.location.Name;
                        }
                        else
                        {
                            return "no place to put the " + item3.Name;
                        }
                    }
                    else
                    {
                        return "no " + text[1] + " found";
                    }
                }
                else
                {
                    return "invalid path command!";
                }
            }
            else { return "invalid transfer command!"; }
        }

        private Location FetchLoc(Player player1, string containerId)
        {
            return player1.Inventory.Fetch(containerId) as Location;
        }

        private Bag FetchBag(Player player1, string containerId)
        {
            return player1.Locate(containerId) as Bag;
        }

        
    }
}
