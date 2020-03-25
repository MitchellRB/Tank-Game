using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Colour
    {
        public uint colour;

        public Colour()
        {
            colour = 0;
        }

        public Colour(byte red, byte green, byte blue, byte alpha)
        {
            colour = 0b_0000_0000_0000_0000_0000_0000_0000_0000;
            colour |= (uint)red << 24;
            colour |= (uint)green << 16;
            colour |= (uint)blue << 8;
            colour |= alpha;
        }

        public byte GetRed()
        {
            return (byte)((colour & 0xff000000) >> 24);
        }
        public void SetRed(byte red)
        {
            colour &= 0x00ffffff;
            colour |= (uint)red << 24;
        }

        public byte GetGreen()
        {
            return (byte)((colour & 0x00ff0000) >> 16);
        }
        public void SetGreen(byte green)
        {
            colour &= 0xff00ffff;
            colour |= (uint)green << 16;
        }

        public byte GetBlue()
        {
            return (byte)((colour & 0x0000ff00) >> 8); ;
        }
        public void SetBlue(byte blue)
        {
            colour &= 0xffff00ff;
            colour |= (uint)blue << 8;
        }

        public byte GetAlpha()
        {
            return (byte)(colour & 0x000000ff);
        }
        public void SetAlpha(byte alpha)
        {
            colour &= 0xffffff00;
            colour |= alpha;
        }
    }
}
