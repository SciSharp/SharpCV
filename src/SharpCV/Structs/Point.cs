using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    internal struct Point
    {
        public float X { get; }
        public float Y { get; }

        public Point(float width, float height)
        {
            X = width;
            Y = height;
        }
    }
}
