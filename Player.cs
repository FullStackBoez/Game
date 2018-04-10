using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    
    class Player
    {
        private int posX;
        private int posY;
        private int maxW;
        private int maxH;
        private int width;
        private int height;
        private int speed;
        private Cars car=null;
        public int x { get { return posX; } }
        public int y { get { return posY; } }
        public Player(int maxW,int maxH,int posX,int posY,int width,int height,int speed)
        {
            this.maxW = maxW;
            this.maxH = maxH;
            this.posX = posX;
            this.posY = posY;
            this.height = height;
            this.width = width;
            this.speed = speed;

        }
        public void attach(Cars c)
        {
            car = c;
        }
        public void deattach()
        {
            car = null;
        }
        public void moveLog()
        {
                if (car != null)
                if(car.dir)
                if (posX + width >= maxW) deattach();
               else posX += car.speed;

                if (car != null)
                if (!car.dir)
                if (posX  <= 0) deattach();
                else posX -= car.speed;
        }
        public void moveUp()
        {
            if (posY <= 0) return;
            else posY -= speed;
        }
        public void moveDown()
        {
            if (posY >=maxH) return;
            else posY += speed;
        }
        public void moveRight()
        {
            if (posX + width >= maxW) return;
            else posX += speed;
        }
        public void moveLeft()
        {
            if (posX <= 0) return;
            else posX -= speed;
        }
        public bool crash(Cars c)
        {
            int left = posX;
            int right = posX + width;
            int top = posY;
            int bottom = posY + height;

            int cleft = c.posX;
            int cright = c.posX + c.width;
            int ctop = c.posY;
            int cbottom = c.posY + c.height;

            return !(left >= cright || right <= cleft || top >= cbottom || bottom <= ctop);
        }
    }
}
