using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Морской_бой_3
{
    internal abstract class gameobject //gameobject
    {
        Point position;
        Point scale;
        public void SetPosition(Point value) => position = value;
        public void SetScale(Point value) => scale = value;
        public int X => position.X;
        public int Y => position.Y;
        public int Widht => scale.X;
        public int Hidht => scale.Y;
        public  abstract void Draw(Graphics g);
    }
}
