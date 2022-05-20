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
                if(text[0] == "move" || text[0] == "go" || text[0] == "head")
                {
                    if (p.Location.HasPath(text[1]))
                    {
                        Path newPath = p.Location.ReturnPath(text[1]);
                        p.Location = newPath.Location;
                        return $"You are now in {p.Location.FullDescription}";
                    }
                    return "404 Not Found";
                }
                return "Where do you want to move?";
            }
            return "I don't know how to move like that";
        }
    }
}
