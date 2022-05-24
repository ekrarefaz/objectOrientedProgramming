using System;
namespace SwinburneAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] {"move","go","head","leave"})
        {
        }
        public override string Execute(Player p, string[] text)
        {
            if(text.Length == 2)
            {
                if(text[0] == "move")
                {
                    if (p.Location.HasPath(text[1]))
                    {
                        Path newPath = p.Location.ReturnPath(text[1]);
                        Location location = newPath.Location;
                        p.Location = newPath.Location;
                        return $"You are now in {p.Location.FullDescription} you head {location.FirstId} and arrived at {location.Name}\nYou look around and find {location.Inventory.ItemList}\nlooking around you see a way to the {location.PathList}";
                    }
                    return "404 Path Not Found";
                }
                return "Where do you want to move?";
            }
            return "I don't know how to move like that";
        }
    }
}
