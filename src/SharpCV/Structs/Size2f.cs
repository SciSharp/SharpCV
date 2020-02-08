using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    public struct Size2f
    {
        public float Width { get; }
        public float Height { get; }

        public Size2f(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Size2f(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public static implicit operator Size2f((float, float) vals)
            => new Size2f(vals.Item1, vals.Item2);

        public static implicit operator Size2f((int, int) vals)
            => new Size2f(vals.Item1, vals.Item2);

        public override string ToString()
        {
            return $"{Width}x{Height}";
        }
    }
}
