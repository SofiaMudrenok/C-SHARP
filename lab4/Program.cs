using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCircleTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("r:");
            var r = Convert.ToInt32(Console.ReadLine());
            var circle_x = Convert.ToInt32(Console.ReadLine());
            var circle_y = Convert.ToInt32(Console.ReadLine());
            var x = Convert.ToInt32(Console.ReadLine());
            var y= Convert.ToInt32(Console.ReadLine());
            TCircle circle = new TCircle(r, circle_x, circle_y, x, y);
            if (circle.isInside())
                Console.Write("Inside");
            else
                Console.Write("Outside");
            Console.WriteLine($"Площа Circle: {circle.Area()}");
            Console.ReadLine();

        }
        class TCircle
        {
            public int r, circle_x, circle_y, x, y;

            public TCircle(int circle_x, int circle_y, int r, int x, int y)
            {
                this.r = r;
                this.circle_x = circle_x;
                this.circle_y = circle_y;
                this.x = x;
                this.y = y;
            }

            public void InputData()
            {
                Console.WriteLine("r:");
                var r = Convert.ToInt32(Console.ReadLine());
                var circle_x = Convert.ToInt32(Console.ReadLine());
                var circle_y = Convert.ToInt32(Console.ReadLine());
                var x = Convert.ToInt32(Console.ReadLine());
                var y = Convert.ToInt32(Console.ReadLine());
            }
            public int Area()
            {
                double pi = Math.PI;
                int area = (int)pi * (r * r);
                return area;
            }
            public bool isInside()
            {
                if ((x - circle_x) * (x - circle_x) + (y - circle_y) * (y - circle_y) <= r * r)
                    return true;
                else
                    return false;
            }
        }
       
    }
}