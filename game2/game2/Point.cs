using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2
{
    class Point
    {
        int x, y;
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        char ch;

        public Point(int x, int y, char ch)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
        }
        public void Draw()
        {
            DrawPoint(ch);
        }
        public void Clear()
        {
            DrawPoint(' ');
        }
        private void DrawPoint(char ch)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }
    }
}
