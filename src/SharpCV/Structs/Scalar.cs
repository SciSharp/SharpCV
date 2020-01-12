using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    public struct Scalar
    {
        public double Val0 { get; }

        public double Val1 { get; }

        public double Val2 { get; }

        public double Val3 { get; }

        public Scalar(double v0, double v1, double v2)
        {
            Val0 = v0;
            Val1 = v1;
            Val2 = v2;
            Val3 = 0;
        }

        public static implicit operator Scalar((double, double, double) vals)
            => new Scalar(vals.Item1, vals.Item2, vals.Item3);
    }
}
