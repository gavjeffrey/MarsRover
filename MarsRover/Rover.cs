using System.Text.RegularExpressions;

namespace MarsRover
{
    public class Rover
    {
        int x = 0, y = 0;
        char orientation;
        Grid Grid;

        public Rover(int currentXPosition, int currentYPosition, char CurrentOrientation, Grid Grid)
        {
            x = currentXPosition;
            y = currentYPosition;
            orientation = CurrentOrientation;
            this.Grid = Grid;
        }

        /// <summary>
        /// Method to move rover.
        /// </summary>
        /// <param name="Commands">String of directions that the rover should follow.</param>
        public bool Move(string Commands)
        {
            Regex movementRegex = new Regex(@"^[MLR]+$");
            if (!movementRegex.IsMatch(Commands))
            {
                return false;
            }

            foreach (var command in Commands)
            {
                if (command == 'M')
                {
                    switch (orientation)
                    {
                        case 'E':
                            if (!Grid.IsInBounds(x + 1, y))
                                return false;
                            x++;
                            break;
                        case 'W':
                            if (!Grid.IsInBounds(x - 1, y))
                                return false;
                            x--;
                            break;
                        case 'N':
                            if (!Grid.IsInBounds(x, y + 1))
                                return false;
                            y++;
                            break;
                        case 'S':
                            if (!Grid.IsInBounds(x, y - 1))
                                return false;
                            y--;
                            break;
                    }
                }
                else
                {
                    switch (orientation)
                    {
                        case 'N':
                            if (command == 'L')
                                orientation = 'W';
                            else if (command == 'R')
                                orientation = 'E';
                            break;
                        case 'E':
                            if (command == 'L')
                                orientation = 'N';
                            else if (command == 'R')
                                orientation = 'S';
                            break;
                        case 'S':
                            if (command == 'L')
                                orientation = 'E';
                            else if (command == 'R')
                                orientation = 'W';
                            break;
                        case 'W':
                            if (command == 'L')
                                orientation = 'S';
                            else if (command == 'R')
                                orientation = 'N';
                            break;
                    }
                }
            }

            return true;
        }

        public string ReportPosition()
        {
            return string.Format("{0} {1} {2}", x, y, orientation);
        }
    }
}
