using System;
using System.Collections.Generic;
namespace SwinburneAdventure
{
    public class CommandProcessor:Command
    {
        private List<Command> _commands;
        public CommandProcessor() : base(new string[] { "command" })
        {
            _commands = new List<Command>()
            {
                new MoveCommand(),
                new Direction(),
                new LookupCommand()
            };
        }

        public override string Execute(Player p, string[] text)
        {                  
            foreach (Command command in _commands)
            {
                if (command.AreYou(text[0].ToLower()))
                {
                    return command.Execute(p, text);
                }
            }
            return $"error in input";
        }
        
    }
}
