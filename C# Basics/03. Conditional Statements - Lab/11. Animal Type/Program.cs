using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Animal_Type
{
    class Program
    {
        static void Main(string[] args)
        {

            string animal = Console.ReadLine();

            if (animal != "dog" && animal != "crocodile" && animal != "tortoise" && animal != "snake")
            {
                Console.WriteLine("unknown");
            }

            else
            {
                switch (animal)
                {
                    case "dog": Console.WriteLine("mammal"); break;
                    case "crocodile": Console.WriteLine("reptile"); break;
                    case "tortoise": Console.WriteLine("reptile"); break;
                    case "snake": Console.WriteLine("reptile"); break;
                }
            }

        }
    }
}
