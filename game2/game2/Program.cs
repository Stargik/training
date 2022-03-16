using System;
using System.Threading;
using System.Threading.Tasks;

namespace game2
{
    class Program
    {
        static readonly int x = 80, y = 28;
        static Wall wall;
        static Basket basket;
        static GameEngine gameEngine;

        static void Initialize()
        {
            Console.SetWindowSize(x, y + 1);
            Console.SetBufferSize(x, y + 1);
            Console.CursorVisible = false;
            wall = new Wall(x, y, '#');
            basket = new Basket(x / 2, y, 5, 2, '0');
            gameEngine = new GameEngine();
        }

        static void Main(string[] args)
        {
            Initialize();
            gameEngine.Start();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                basket.Move(key);
            }
            
        }
    }
}
