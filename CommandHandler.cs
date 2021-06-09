using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    public class CommandHandler
    {
        const int MaxX = 10;
        const int MaxY = 10;
        int _x, _y, _currentDirectionIdx;
        List<(char direction, Action handler)> DirectionActions; 

        public CommandHandler(int x, int y, char initialDiection)
        {
            _x = x; _y = y;
           
            DirectionActions = new List<(char direction, Action handler)>
            { ('N', MoveNorth), ('E', MoveEast), ('S', MoveSouth), ('W', MoveWest) };

            // make turn based on directions index not on values so 0:N, E:1, S:2 ,W:3
            var direction = DirectionActions.First(x => x.direction == initialDiection); 
            _currentDirectionIdx = DirectionActions.IndexOf(direction);
        }

        public void TurnLeftCmd()
        {
            _currentDirectionIdx = (_currentDirectionIdx == 0) ? (DirectionActions.Count - 1) : --_currentDirectionIdx;
        }
        public void TurnRightCmd()
        {
            _currentDirectionIdx = ++_currentDirectionIdx % 4;
        }

        public void MoveCmd()
        {
            // increments x or y coordinate based on current direction.
            DirectionActions[_currentDirectionIdx].handler.Invoke(); 
        }

        void MoveNorth() { _y = ++_y % MaxY; }

        void MoveEast() { _x = ++_x % MaxX; }

        void MoveSouth() { _y = _y == 0 ? MaxY - 1 : --_y; }

        void MoveWest() { _x = _x == 0 ? MaxX - 1 : --_x; }

        internal string GetLocation()
        {
            return $"{_x}:{_y}:{DirectionActions[_currentDirectionIdx].direction}";
        }
    }
}
