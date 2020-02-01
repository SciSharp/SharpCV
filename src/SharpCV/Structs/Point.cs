using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(float x, float y)
        {
            X = Convert.ToInt32(x);
            Y = Convert.ToInt32(y);
        }

        public static implicit operator Point((float, float) vals)
            => new Point(vals.Item1, vals.Item2);

        public static implicit operator Point((int, int) vals)
            => new Point(vals.Item1, vals.Item2);

        public override string ToString()
        {
            return $"{X}x{Y}";
        }
    }
}
