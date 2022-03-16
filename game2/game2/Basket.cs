using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2
{
    class Basket
    {
        int width;
        int height;
        int x, y;
        char ch;
        LinkedList<Point> basketPoints;

        public Basket(int x, int y, int width, int height, char ch)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.ch = ch;
            basketPoints = new LinkedList<Point>();
            for (int k = y - height; k < y; k++)
            {
                for (int i = x - width; i < x; i++)
                {
                    Point point = new Point(i, k, ch);
                    point.Draw();
                    if(k == y - height)
                        basketPoints.AddLast(point);
                }
            }
        }

        public void MoveLeft()
        {
            for (int i = y - height; i < y; i++)
            {
                Point pointAdd = new Point(x - width - 1, i, ch);
                Point pointRemove = new Point(x - 1, i, ch);
                pointRemove.Clear();
                pointAdd.Draw();
                if (i == y - height)
                {
                    basketPoints.RemoveLast();
                    basketPoints.AddFirst(pointAdd);
                }
            }
            x--;
        }
        public void MoveRight()
        {
            for (int i = y - height; i < y; i++)
            {
                Point pointAdd = new Point(x, i, ch);
                Point pointRemove = new Point(x - width, i, ch);
                pointRemove.Clear();
                pointAdd.Draw();
                if (i == y - height)
                {       
                    basketPoints.RemoveFirst();
                    basketPoints.AddLast(pointAdd);
                }
            }
            x++;
        }

        public void Move(ConsoleKeyInfo consoleKey)
        {
            switch (consoleKey.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (x - width - 1 > 0)
                    {
                        MoveLeft();
                    }   
                    break;
                case ConsoleKey.RightArrow:
                    if (x < Console.WindowWidth)
                    {
                        MoveRight();
                    }
                    break;
            }
        }
    }
}
