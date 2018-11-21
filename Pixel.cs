using System.Drawing;

namespace Recognizer
{
    public class Pixel
    {
        public Pixel(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Pixel(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public override string ToString()
        {
            return string.Format("Pixel({0}, {1}, {2})", R, G, B);
        }
    }
}