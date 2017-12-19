using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Grid
    {
        private int XBoundary;
        private int YBoundary;

        public Grid(int XBoundary, int YBoundary)
        {
            this.XBoundary = XBoundary;
            this.YBoundary = YBoundary;
        }

        public bool IsInBounds(int X, int Y)
        {
            if (X <= XBoundary && Y <= YBoundary)
                return true;

            return false;
        }
    }
}
