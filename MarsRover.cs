using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class MarsRover
    {
        CommandHandler _commandHandler;
        Dictionary<char, Action> _commands;

        public MarsRover(int x, int y, char initialDiection)
        {
            _commandHandler = new CommandHandler(x, y, initialDiection);

            _commands = new Dictionary<char, Action> {
                { 'R', _commandHandler.TurnRightCmd },
                { 'L', _commandHandler.TurnLeftCmd },
                { 'M', _commandHandler.MoveCmd } };
        }

        public string Execute(string commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                if (_commands.TryGetValue(commands[i], out Action commandHandler))
                    commandHandler.Invoke();
            }

            return _commandHandler.GetLocation();
        }
    }
}
