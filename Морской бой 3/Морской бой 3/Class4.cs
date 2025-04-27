using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Морской_бой_3
{
    internal class Efect:gameobject//Efect
    {
        static Image image;
        public static void SetImage(Image value) => image = value;
        public Efect(Point position, Point size)
        {
            SetPosition(position);
            SetScale(size);
        }
        public override void Draw(Graphics g) => g.DrawImage(image, X, Y, Widht, Hidht);
        
            
        
    }
}
