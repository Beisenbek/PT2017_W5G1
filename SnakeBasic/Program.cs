using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeBasic
{
    public class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Food
    {
        public char sign = '$';
        public Point location;
        public Food()
        {
            this.location = new Point(new Random().Next() % 40, new Random().Next() % 40);
        }
        public void Draw()
        {
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }
    }
    public class Worm
    {
        public char sign = '*';
        public bool isAlive = true;
        public List<Point> body = new List<Point>();
        public Worm()
        {
            body.Add(new Point(10, 10));
        }

        public void Draw()
        {
           
            for (int i = 0; i < this.body.Count; ++i)
            {
                Console.SetCursorPosition(this.body[i].x, this.body[i].y);
                Console.Write(this.sign);
            }
        }
        public void CheckIsFoodReached(Food f)
        {
            for (int i = 0; i < this.body.Count; ++i)
            {
                if (this.body[i].x == f.location.x && this.body[i].y == f.location.y)
                {
                    this.body.Add(new Point(f.location.x, f.location.y));
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Worm w = new Worm();
            Food f = new Food();
            while(w.isAlive)
            {
                Console.Clear();
                w.Draw();
                f.Draw();
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        w.body[0].y--;
                        break;
                    case ConsoleKey.DownArrow:
                        w.body[0].y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        w.body[0].x--;
                        break;
                    case ConsoleKey.RightArrow:
                        w.body[0].x++;
                        break;

                }

                w.CheckIsFoodReached(f);
            }
        }
    }
}
