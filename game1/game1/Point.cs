using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game1
{
    class Point
    {
        char ch;
        int x;
        int y;

        public Point(int x, int y, char ch)
        {
            this.ch = ch;
            this.x = x;
            this.y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public void Clear()
        {
            DrawPoint(' ');
        }
        public void Draw()
        {
            DrawPoint(ch);
        }
        private void DrawPoint(char ch)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }

        public static bool operator == (Point a, Point b)
        {
            return (a.X == b.X && a.Y == b.Y);
        }
        public static bool operator !=(Point a, Point b)
        {
            return (a.X != b.X || a.Y != b.Y);
        }
    }
}
