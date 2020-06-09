using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {

            double L = double.Parse(Console.ReadLine());
            double W = double.Parse(Console.ReadLine());
            double A = double.Parse(Console.ReadLine());

            double roomArea = L * W;
            double wardrobeArea = A * A;
            double benchArea = roomArea / 10;
            double freeSpace = roomArea - (wardrobeArea + benchArea);

            double dancersTotal = freeSpace / ((40 + 7000) * 0.0001);

            Console.WriteLine(Math.Floor(dancersTotal));
        }
    }
}
