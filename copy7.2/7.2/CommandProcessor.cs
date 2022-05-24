using System;
using System.Collections.Generic;
namespace _7._2
{
    public class CommandProcessor : Command
    {
        private List<Command> _comnd;
        public CommandProcessor() : base(new string[] { "command" })
        {
            _comnd = new List<Command>
            {
                new LookCommand(),
                new MoveCommand(),
                new Direction()
            };
        }

        public List<Command> comnd
        {
            get => _comnd;
        }

        public override string Execute(Player player1, string[] text)
        {
            foreach (Command c in _comnd)
            {
                if (c.AreYou(text[0].ToUpper()))
                {
                    return c.Execute(player1, text);
                }
            }

            return "Error in input";
        }

    }
}
