using System;
using System.Threading;
using System.Threading.Tasks;

namespace game1
{
    class Program
    {
        static readonly int x = 80;
        static readonly int y = 26;

        static Walls walls;
        static FoodFactory foodFactory;
        static Snake snake;
        static Timer timer;

        static void Main(string[] args)
        {
            
            Console.SetWindowSize(x + 1, y + 1);
            Console.SetBufferSize(x + 1, y + 1);
            Console.CursorVisible = false;
            walls = new Walls(x, y, '#');
            foodFactory = new FoodFactory(x, y, '@');
            snake = new Snake(x / 2, y / 2, 3);
            foodFactory.CreateFood();
            timer = new Timer(Loop, null, 0, 200);
            
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    snake.Rotation(keyInfo.Key);
                }
            }

            
            

            //Console.ReadKey();
        }
        static void Loop(object obj)
        {
            //if (walls.IsHit(snake.GetHead()) || snake.IsHit(snake.GetHead()))
            //{
            //    timer.Change(0, Timeout.Infinite);
            //}
            //else if (snake.Eat(foodFactory.food))
            //{
            //    foodFactory.CreateFood();
            //}
            //else
            {
                snake.Move();
            }
        }
    }
}
