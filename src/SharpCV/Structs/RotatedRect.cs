using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    public struct RotatedRect
    {
        public Point2f Center { get; }

        public Size2f Size { get; }

        public float Angle;

        public RotatedRect(Point2f center, Size2f size, float angle)
        {
            Size = size;
            Center = center;
            Angle = angle;
        }

        public void Deconstruct(out Point2f center, out Size2f size, out float angle)
        {
            center = Center;
            size = Size;
            angle = Angle;
        }

        public override string ToString()
        {
            return $"{Center}, {Size}, {Angle}";
        }
    }
}
