using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game1
{
    class Snake
    {
        private Queue<Point> snake;
        private Direction direction;
        private int step = 1;
        private Point tail;
        private Point head;
        bool rotate = true;

        public Snake(int x, int y, int length)
        {
            direction = Direction.RIGHT;
            snake = new Queue<Point>();
            for (int i = x - length; i < x; i++)
            {
                Point p = new Point(i, y, '*');
                snake.Enqueue(p);
                p.Draw();
            }
        }
        public Point GetHead()
        {
            return snake.Last();
        }
        public void Move()
        {
            head = GetNextPoint();
            snake.Enqueue(head);
            tail = snake.Peek();
            snake.Dequeue();
            tail.Clear();
            head.Draw();
            rotate = true;
        }

        public Point GetNextPoint()
        {
            Point point = GetHead();
            switch (direction)
            {
                case Direction.LEFT:
                    point.X -= step;
                    break;
                case Direction.RIGHT:
                    point.X += step;
                    break;
                case Direction.UP:
                    point.Y -= step;
                    break;
                case Direction.DOWN:
                    point.Y += step;
                    break;
            }
            return point;
        }

        public void Rotation(ConsoleKey key)
        {
            if (rotate)
            {
                switch (direction)
                {
                    case Direction.LEFT:
                    case Direction.RIGHT:
                        if (key == ConsoleKey.DownArrow)
                            direction = Direction.DOWN;
                        else if (key == ConsoleKey.UpArrow)
                            direction = Direction.UP;
                        break;
                    case Direction.UP:
                    case Direction.DOWN:
                        if (key == ConsoleKey.LeftArrow)
                            direction = Direction.LEFT;
                        if (key == ConsoleKey.RightArrow)
                            direction = Direction.RIGHT;
                        break;
                }
                rotate = false;
            }
        }
        public bool IsHit(Point point)
        {
            for (int i = snake.Count - 2; i > 0; i--)
            {
                if (snake[i] == point)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Eat(Point point)
        {
            head = GetNextPoint();
            if (point == head)
            {
                snake.Enqueue(head);
                head.Draw();
                return true;
            }
            return false;
        }

    }
}
