using System;
using System.Collections.Generic;
namespace _7._2
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
        }

        public override string Execute(Player player1, string[] text)
        {
            if (text[0] == "move")
            {
                if (text.Length == 2)
                {
                    if (player1.location.hasPath(text[1]))
                    {
                        Path _path = player1.location.returnPath(text[1]);
                        Location loctn = _path.location;
                        player1.location = loctn;
                        return "You head " + loctn.FirstId + "\n"
                            + "You go " + _path.fullexcp + "\n"
                            + "You have arrived in a " + loctn.Name;
                    }
                    else
                    {
                        return "Error!";
                    }
                }
                else
                {
                    return "place?";
                }
            }
            else { return "invalid move command!"; }
        }
    }
}
