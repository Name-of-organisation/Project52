using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Морской_бой_3
{
    internal class Cell: gameobject
    {
        bool breaking = false;
        bool forPlayer = false;
        bool ship = false;
        internal bool isBreaking;
        internal bool isShip;

        public Cell(Point position, int size, bool forPlayer)
        {
            SetPosition(position);
            SetScale(new Point(size, size));
            this.forPlayer = forPlayer;
        }
    public void SetShip (bool value) => ship = value;
        public bool IsShip => ship;
        public bool IsBreaking => breaking;
        public override void Draw(Graphics g) 
        {
            if (!breaking)

            {
                g.DrawRectangle(new Pen(Color.White), X, Y, Ship.Width, Ship.Height);
                if (forPlayer && ship)
                    Ship.Draw(g, X, Y);
            }
            else
                g.FillRectangle(Brushes.Red, X, Y, Ship.Width, Ship.Height);
        }
        public bool AttackCell() => breaking = true;
        public bool AttackCell(Point pos)
        {
            if (pos.X > X && pos.X < X + Ship.Width && pos.Y > Y && pos.Y < Y + Ship.Height && !breaking)
                return AttackCell();
            return false;

        }
    }
}
