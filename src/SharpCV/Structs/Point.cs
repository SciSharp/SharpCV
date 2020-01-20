using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int width, int height)
        {
            X = width;
            Y = height;
        }

        public Point(float width, float height)
        {
            X = Convert.ToInt32(width);
            Y = Convert.ToInt32(height);
        }

        public static implicit operator Point((float, float) vals)
            => new Point(vals.Item1, vals.Item2);

        public static implicit operator Point((int, int) vals)
            => new Point(vals.Item1, vals.Item2);
    }
}
