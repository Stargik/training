using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2
{
    class EggsFactory
    {
        List<Egg> eggs;
        Random random;
        char ch;
        public EggsFactory(char ch)
        {
            this.ch = ch;
            this.random = new Random();
            this.eggs = new List<Egg>();
        }
        public void DropEgg()
        {
            Egg egg = new Egg(random.Next(2, Console.WindowWidth), 0, ch);
            eggs.Add(egg);
            egg.point.Draw();
        }
        public void MoveEggs()
        {
            if (eggs.Count > 0)
            {
                foreach (var egg in eggs)
                {
                    egg.point.Clear();
                    egg.point.Y = egg.point.Y + 1;
                    egg.point.Draw();
                }
            }

        }
        public bool StateOfEggs()
        {
            foreach (var egg in eggs)
            {
                if (!egg.IsOk())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
