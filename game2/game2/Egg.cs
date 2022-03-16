using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2
{
    class Egg
    {
        int x, y;
        public Point point;
        public Egg(int x, int y, char ch)
        {
            point = new Point(x, y, ch);
        }
        public bool IsOk()
        {
            return (point.Y < Console.WindowHeight);
        }

    }
}
