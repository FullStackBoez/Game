using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Cars
    {
        public int posX;
        public int posY;
        private int maxW;
        private int maxH;
        public int width;
        public int height;
        public int speed;
        public bool dir = false;
        private Random rand;
        public int x { get { return posX; } }
        public int y { get { return posY; } }
        public Cars(int maxW, int maxH, int posX, int posY, int width, int height, int speed)
        {
            this.maxW = maxW;
            this.maxH = maxH;
            this.posX = posX;
            this.posY = posY;
            this.height = height;
            this.width = width;
            this.speed = speed;
            rand = new Random();
        }
        public void move(bool flag)
        {
            dir = flag;
            if (flag)
            {
                if (posX >= maxW + 100) posX = rand.Next(-1000,-80);
                else posX += speed;
            }
            else
            {
                if (posX <= -100) posX = maxW+rand.Next(80,500);
                else posX -= speed;
            }
        }
    }
}
