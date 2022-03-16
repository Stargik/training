using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1
{
    class Walls
    {
        char ch;
        List<Point> wall = new List<Point>();

        public Walls(int x, int y, char ch)
        {
            this.ch = ch;
            DrawHorizontal(x, 0);
            DrawHorizontal(x, y);
            DrawVertical(0, y);
            DrawVertical(x, y);
            
        }

        private void DrawHorizontal(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Point point = new Point(i, y, ch);
                point.Draw();
                wall.Add(point);
            }
        }

        private void DrawVertical(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Point point = new Point(x, i, ch);
                point.Draw();
                wall.Add(point);
            }
        }
        public bool IsHit(Point point)
        {
            foreach (var item in wall)
            {
                if(point == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
