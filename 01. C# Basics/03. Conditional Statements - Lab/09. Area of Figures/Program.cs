using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {

            string figure = Console.ReadLine();
            double area = 0;

            switch (figure)
            {

                case "square":
                    {
                        double a = double.Parse(Console.ReadLine());
                        area = a * a;
                        break;
                    }

                case "rectangle":
                    {
                        double a = double.Parse(Console.ReadLine());
                        double b = double.Parse(Console.ReadLine());
                        area = a * b;
                        break;
                    }

                case "circle":
                    {
                        double a = double.Parse(Console.ReadLine());
                        area = Math.PI * (a * a);
                        break;
                    }

                case "triangle":
                    {
                        double a = double.Parse(Console.ReadLine())
                        double b = double.Parse(Console.ReadLine());
                        area = a * b / 2;
                        break;
                    }
            }
            Console.WriteLine($"{area:F3}");
        }
    }
}