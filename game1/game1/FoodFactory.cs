using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1
{
    class FoodFactory
    {
        int x;
        int y;
        char ch;
        public Point food { get; private set; }
        Random random = new Random();

        public FoodFactory(int x, int y, char ch)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
        }

        public void CreateFood()
        {
            food = new Point(random.Next(2, x - 2), random.Next(2, y - 2), ch);
            food.Draw();
        }
    }
}
