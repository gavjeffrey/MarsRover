using System;
using System.Text.RegularExpressions;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rover Initialized. Press esc to disconnect.");

            var key = new ConsoleKeyInfo();

            Grid grid = GetGrid();

            do
            {
                GetCurrentPosition(out int x, out int y, out char orientation);

                var strMovements = GetMovementCommand();

                Rover rover = new Rover(x, y, orientation, grid);

                if (!rover.Move(strMovements))
                {
                    Console.WriteLine("Movement would result in invalid grid position, Rover stopped.");
                }

                Console.WriteLine("My current position is: {0}", rover.ReportPosition());

                Console.WriteLine("Press esc to exit. Press any other key to continue sending commands on this grid...");

                key = Console.ReadKey();
            }
            while (key.Key != ConsoleKey.Escape);
        }

        public static Grid GetGrid()
        {
            Console.WriteLine("Waiting for grid command...");

            var strGridSize = Console.ReadLine();
            int gridSize = -1;
            
            //check that input is valid int and that x and y are of equal units i.e. number with length 3 is not acceptable because we don't know how to split it to get x and y
            while (!int.TryParse(strGridSize, out gridSize) || strGridSize.Length % 2 > 0)
            {
                Console.WriteLine("Invalid grid sent. Please send valid grid size.");
                strGridSize = Console.ReadLine();
            }

            var x = int.Parse(strGridSize.Substring(0, strGridSize.Length / 2));
            var y = int.Parse(strGridSize.Substring(strGridSize.Length / 2));
            
            return new Grid(x, y);
        }

        public static void GetCurrentPosition(out int x, out int y, out char orientation)
        {
            Console.WriteLine("Waiting for my position verification...");

            var strCurrentPos = Console.ReadLine();

            Regex positionRegex = new Regex(@"([0-9]+)\s(N|S|E|W)");
            while (!positionRegex.IsMatch(strCurrentPos))
            {
                Console.WriteLine("Invalid position sent. Please send valid position.");
                strCurrentPos = Console.ReadLine();
            }

            var strPositionCommand = strCurrentPos.Split(' ');

                var strPositionOnGrid = strPositionCommand[0];

            x = int.Parse(strPositionOnGrid.Substring(0, strPositionOnGrid.Length / 2));
            y = int.Parse(strPositionOnGrid.Substring(strPositionOnGrid.Length / 2));

            orientation = char.Parse(strPositionCommand[1]);
        }

        public static string GetMovementCommand()
        {
            Console.WriteLine("Waiting for next directions...");

            var strMovement = Console.ReadLine();

            Regex movementRegex = new Regex(@"^[MLR]+$");
            while (!movementRegex.IsMatch(strMovement))
            {
                Console.WriteLine("Invalid position sent. Please send valid position.");
                strMovement = Console.ReadLine();
            }

            return strMovement;
        }
    }
}
