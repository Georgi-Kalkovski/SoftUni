using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            switch (product)
            {

                case "coffee":
                    {
                        if (city == "Sofia")
                        {
                            Console.WriteLine(amount * 0.50);
                        }
                        else if (city == "Plovdiv")
                        {
                            Console.WriteLine(amount * 0.40);
                        }
                        else if (city == "Varna")
                        {
                            Console.WriteLine(amount * 0.45);
                        }
                        break;
                    }

                case "water":
                    {
                        if (city == "Sofia")
                        {
                            Console.WriteLine(amount * 0.80);
                        }
                        else if (city == "Plovdiv")
                        {
                            Console.WriteLine(amount * 0.70);
                        }
                        else if (city == "Varna")
                        {
                            Console.WriteLine(amount * 0.70);
                        }
                        break;
                    }

                case "beer":
                    {
                        if (city == "Sofia")
                        {
                            Console.WriteLine(amount * 1.20);
                        }
                        else if (city == "Plovdiv")
                        {
                            Console.WriteLine(amount * 1.15);
                        }
                        else if (city == "Varna")
                        {
                            Console.WriteLine(amount * 1.10);
                        }
                        break;
                    }

                case "sweets":
                    {
                        if (city == "Sofia")
                        {
                            Console.WriteLine(amount * 1.45);
                        }
                        else if (city == "Plovdiv")
                        {
                            Console.WriteLine(amount * 1.30);
                        }
                        else if (city == "Varna")
                        {
                            Console.WriteLine(amount * 1.35);
                        }
                        break;
                    }

                case "peanuts":
                    {
                        if (city == "Sofia")
                        {
                            Console.WriteLine(amount * 1.60);
                        }
                        else if (city == "Plovdiv")
                        {
                            Console.WriteLine(amount * 1.50);
                        }
                        else if (city == "Varna")
                        {
                            Console.WriteLine(amount * 1.55);
                        }
                        break;
                    }
            }

        }
    }
}
