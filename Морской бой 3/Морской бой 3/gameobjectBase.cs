using System.Drawing;

namespace Морской_бой_3
{
    abstract class gameobjectBase
    {
        Point position;
        Point scale;
        public void SetPosition(Point value) => position = value;
        public void SetScale(Point value) => scale = value;
        public int X => position.X;
        public int Y => position.Y;
        public int Width => scale.X;
        public int Height => scale.Y;
        public abstract void Draw(Graphics g);
    }
}