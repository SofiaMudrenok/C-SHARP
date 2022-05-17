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
            TCircle circle = new TCircle(r);
            Console.WriteLine($"Площа Circle: {circle.Area()}");
            Console.WriteLine("///////////////");
            var h = Convert.ToInt32(Console.ReadLine());
            TCylinder cylinder = new TCylinder(h,r);
            Console.WriteLine($"Volume Cylinder: {cylinder.Volume()}");
            Console.ReadLine();
        }
        class TCircle
        {
            public int r;
            public TCircle()
            {
                r = 0;
            }

            public TCircle( int r)
            {
                this.r = r;
            }

            public void InputData()
            {
                Console.WriteLine("r:");
                var r = Convert.ToInt32(Console.ReadLine());
            }
            public int Area()
            {
                double pi = Math.PI;
                int area = (int)pi * (r * r);
                return area;
            }
        }
        class TCylinder : TCircle
        {
            public int h;
            public TCylinder(int h,int r) : base(r)
            {
                this.h = h;
            }
            public int Volume()
            {
                return base.Area()* h;
            }
        }
       
    }
}