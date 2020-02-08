using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    public struct Point2f
    {
        public float X { get; }
        public float Y { get; }

        public Point2f(int x, int y)
        {
            X = Convert.ToSingle(x);
            Y = Convert.ToSingle(y);
        }

        public Point2f(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator Point2f((float, float) vals)
            => new Point2f(vals.Item1, vals.Item2);

        public static implicit operator Point2f((int, int) vals)
            => new Point2f(vals.Item1, vals.Item2);

        public override string ToString()
        {
            return $"{X}x{Y}";
        }
    }
}
