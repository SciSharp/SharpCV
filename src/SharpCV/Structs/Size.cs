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
        /// <summary>
        /// 自动实现元组解构
        /// </summary>
        /// <param name="ih"></param>
        /// <param name="iw"></param>
        public void Deconstruct(out int ih, out int iw)
        {
            ih = Height;
            iw = Width;
        }
    }
}
