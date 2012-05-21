using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolEngine
{
    public struct Point
    {
        public int Top;
        public int Left;

        public Point(int top, int left)
        {
            this.Top = top;
            this.Left = left;
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Left == p2.Left && p1.Top == p2.Top;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return p1.Left != p2.Left || p1.Top != p2.Top;
        }
    }
}
