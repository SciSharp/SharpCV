using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    public struct Rect
    {
        public int X { get; }
        public int Y { get; }

        public int Width { get; }
        public int Height { get; }

        public Rect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public static implicit operator Rect((int, int, int, int) vals)
            => new Rect(vals.Item1, vals.Item2, vals.Item3, vals.Item4);

        public void Deconstruct(out int x, out int y, out int width, out int height)
        {
            x = X;
            y = Y;
            width = Width;
            height = Height;
        }
    }
}
