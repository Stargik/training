using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game2
{
    class GameEngine
    {
        EggsFactory factory;
        bool stateOfEggs;
        public GameEngine()
        {
            this.factory = new EggsFactory('@');
            stateOfEggs = true;
            
        }

        public void Start()
        {
            Task drop = new Task(DropEggs);
            Task move = new Task(MoveEggs);
            drop.Start();
            move.Start();
        }
        private void DropEggs()
        {
            while (true)
            {
                factory.DropEgg();
                Thread.Sleep(5000);
            }
        }
        private void MoveEggs()
        {
            while (stateOfEggs)
            {
                factory.MoveEggs();
                stateOfEggs = factory.StateOfEggs();
                Thread.Sleep(1000);
            }
        }
    }
}
