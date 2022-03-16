using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2
{
    
    class Wall
    {
        char ch;
        List<Point> walls = new List<Point>();
        public Wall(int x, int y, char ch)
        {
            this.ch = ch;
            HorizontalRaw(x, y);
        }

        private void HorizontalRaw(int x, int y)
        {
            Point point;
            for (int i = 0; i < x; i++)
            {
                point = new Point(i, y, ch);
                point.Draw();
                walls.Add(point);
            }
        }
        private void VerticalRaw(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Point point = new Point(x, i, ch);
                point.Draw();
            }
        }

    }
    
}
