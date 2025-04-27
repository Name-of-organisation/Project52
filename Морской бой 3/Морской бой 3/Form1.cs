using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Морской_бой_3
{
    public partial class Form1 : Form
    {
        Cell[,] playerCells;
        Cell[,] pcCells;
        List<Efect> efects = new List<Efect>();
        Image back;
        int count = 10;
        bool endGame = false;

        public Form1()
        {
            InitializeComponent();
        }
        void Update()
        {
            Bitmap frame = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(frame);
            g.DrawImage(back,0,0,frame.Width,frame.Height);
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                {
                    pcCells[i, j].Draw(g);
                    playerCells[i, j].Draw(g);
                }
            if(efects.Count != 0)
                foreach(var i  in efects)
                    i.Draw(g);
                CheckShips(pcCells, "You win", g);
                CheckShips(playerCells, "PC win", g);
                pictureBox1.BackgroundImage = frame;
            }
            Cell[,] CreateField(int offset, bool player)
            {
                int cellSize = 40;
                Cell[,] cells = new Cell[count, count];
                for (int i = 0;i < count;i++)
                    for (int j = 0;j < count;j++)
                    {
                        cells[i,j] = new Cell(new Point(offset + (cellSize * i), 70 + (cellSize * j)), cellSize,player);
                    }
                return cells;
            }
            void PcAttack()
            {
                Random random = new Random();
                int x, y;
                Cell cell;
                do
                {
                    x = random.Next(0, count);
                    y = random.Next(0, count);
                }
                while ((cell = playerCells[x, y]).isBreaking);
                  cell.AttackCell();
                if (cell.isShip)
                    AddEfect(cell);
            }
            void CheckShips(Cell[,] cells, string s, Graphics g)
            {
                foreach(var i in cells)
                    if (i.isShip && !i.isBreaking)
                    {
                        return;
                    }
                g.DrawString(s, new Font("Arial", 50), Brushes.Black, 370, 150);
                endGame = true;
            }
            void CreateShip(ref Cell[,] cells, int offset)
            {
                for (int i = 0; i < count; i++) 
                {
                    Random random = new Random(DateTime.Now.Millisecond - offset);
                    int x, y;
                    do
                    {
                        x = random.Next(0, count);
                        y = random.Next(0, count);
                    }
                    while(cells[x, y].isShip);
                    cells[x, y].SetShip(true);
                 }
             }
            void AddEfect(Cell cell) => efects.Add(new Efect(new Point(cell.X, cell.Y), new Point(40,40)));
            private void Form1_load(object sender, EventArgs e)
            {
            back = Image.FromFile("Water.png");
            Ship.SetImage(Image.FromFile("Ship.png"));
            Ship.SetSize(new Point(40, 40));
            Efect.SetImage(Image.FromFile("Exception.png"));
            playerCells = CreateField(500, true);
            pcCells = CreateField(500, false);
            CreateShip(ref playerCells,50);
            CreateShip(ref pcCells,897);
            Update();
            }

      

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!endGame)
                foreach (var i in pcCells)
                {
                    if (i.AttackCell(new Point(e.X, e.Y)))
                    {
                        if (i.isShip)
                            AddEfect(i);
                        PcAttack();
                        Update();
                        return;
                    }

                }
        }
    }
}
