using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    public struct Size
    {
        public int Width { get; }
        public int Height { get; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
