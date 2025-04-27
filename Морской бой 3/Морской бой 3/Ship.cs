using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Морской_бой_3
{
    class Ship// Ship
    {
        static Image Image;
        static public int Width, Height;
        static public void SetImage(Image value) => Image = value;
        static public void SetSize(Point size)
        {
            Width = size.X;
            Height = size.Y;
        }
        public static void Draw(Graphics g, int X, int Y) => g.DrawImage(Image, X, Y, Width, Height);

      
    }
}
