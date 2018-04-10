using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogger
{
    public partial class GameWindow : Form
    {
        private Player p1;
        private Cars[] rowCars;
        private Cars[] rowLogs;
        public GameWindow()
        {
            p1 = new Player(1000, 800, (1000/2)-40, 800, 80, 80, 80);
            rowCars = new Cars[10];
            rowLogs = new Cars[10];

            rowCars[0] = new Cars(1000, 800, 0, 720, 80, 80, 20);
            rowCars[1] = new Cars(1000, 800, -120, 720, 80, 80, 30);
            rowCars[2] = new Cars(1000, 800, -350, 720, 80, 80, 20);

            rowCars[3] = new Cars(1000, 800, 880, 640, 80, 80, 30);
            rowCars[4] = new Cars(1000, 800, 1060, 640, 80, 80, 30);
            rowCars[5] = new Cars(1000, 800, 800, 640, 80, 80, 20);

            rowCars[6] = new Cars(1000, 800, -80, 560, 80, 80, 40);
            rowCars[7] = new Cars(1000, 800, -300, 560, 80, 80, 45);

            rowCars[8] = new Cars(1000, 800, 880, 480, 160, 80, 20);
            rowCars[9] = new Cars(1000, 800, 1000, 480, 160, 80, 25);




            rowLogs[0] = new Cars(1000, 800, 0, 320, 200, 80, 20);
            rowLogs[1] = new Cars(1000, 800, -120, 320, 200, 80, 30);
            rowLogs[2] = new Cars(1000, 800, -350, 320, 200, 80, 20);

            rowLogs[3] = new Cars(1000, 800, 880, 240, 220, 80, 30);
            rowLogs[4] = new Cars(1000, 800, 1060, 240, 220, 80, 30);
            rowLogs[5] = new Cars(1000, 800, 800, 240, 220, 80, 20);

            rowLogs[6] = new Cars(1000, 800, -80, 160, 150, 80, 40);
            rowLogs[7] = new Cars(1000, 800, -300, 160, 150, 80, 45);

            rowLogs[8] = new Cars(1000, 800, 880, 80, 160, 80, 20);
            rowLogs[9] = new Cars(1000, 800, 1000, 80, 160, 80, 25);
            InitializeComponent();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Aqua, p1.x, p1.y, 80, 80);

            for (int i=0;i<3;i++)
                e.Graphics.FillRectangle(Brushes.Blue, rowCars[i].x, rowCars[i].y, 80, 80);

            for (int i = 3; i < 6; i++)
                e.Graphics.FillRectangle(Brushes.Black, rowCars[i].x, rowCars[i].y, 80, 80);

            for (int i = 6; i <8; i++)
                e.Graphics.FillRectangle(Brushes.Red, rowCars[i].x, rowCars[i].y, 80, 80);

            for (int i = 8; i < 10; i++)
                e.Graphics.FillRectangle(Brushes.Yellow, rowCars[i].x, rowCars[i].y, 160, 80);


            for (int i = 0; i < 3; i++)
                e.Graphics.FillRectangle(Brushes.Blue, rowLogs[i].x, rowLogs[i].y, 200, 80);

            for (int i = 3; i < 6; i++)
                e.Graphics.FillRectangle(Brushes.Black, rowLogs[i].x, rowLogs[i].y, 220, 80);

            for (int i = 6; i < 8; i++)
                e.Graphics.FillRectangle(Brushes.Red, rowLogs[i].x, rowLogs[i].y, 150, 80);

            for (int i = 8; i < 10; i++)
                e.Graphics.FillRectangle(Brushes.Yellow, rowLogs[i].x, rowLogs[i].y, 160, 80);

        }

        private void Timer(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                rowCars[i].move(true);

            for (int i = 3; i < 6; i++)
                rowCars[i].move(false);

            for (int i = 6; i < 8; i++)
                rowCars[i].move(true);

            for (int i = 8; i < 10; i++)
                rowCars[i].move(false);


            for (int i = 0; i < 3; i++)
                rowLogs[i].move(true);

            for (int i = 3; i < 6; i++)
                rowLogs[i].move(false);

            for (int i = 6; i < 8; i++)
                rowLogs[i].move(true);

            for (int i = 8; i < 10; i++)
                rowLogs[i].move(false);

          foreach (Cars c in rowCars)
            {
                if (p1.crash(c))
                {
                    Debug.WriteLine("Lost");
                }
            }

            if(p1.y<400)
            {
                bool flag = false;
                foreach(Cars c in rowLogs)
                {
                    if (p1.crash(c))
                    {
                        flag = true;
                        p1.attach(c);
                        p1.moveLog();
                    }
                }
                if(!flag) Debug.WriteLine("Lost");
            }
            Invalidate();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) p1.moveUp();
            if (e.KeyCode == Keys.Down) p1.moveDown();
            if (e.KeyCode == Keys.Left) p1.moveLeft();
            if (e.KeyCode == Keys.Right) p1.moveRight();
        }
    }
}
