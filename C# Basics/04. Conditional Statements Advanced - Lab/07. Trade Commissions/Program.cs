using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {

            string city = Console.ReadLine();
            double commission = double.Parse(Console.ReadLine());

            switch (city)
            {
                case "Sofia":
                    {
                        if (commission >= 0 && commission <= 500)
                        {
                            Console.WriteLine($"{(commission * 0.05):F2}");
                        }

                        else if (commission > 500 && commission <= 1000)
                        {
                            Console.WriteLine($"{(commission *0.07):F2}");
                        }

                        else if (commission > 1000 && commission <= 10000)
                        {
                            Console.WriteLine($"{(commission * 0.08):F2}");
                        }

                        else if (commission > 10000)
                        {
                            Console.WriteLine($"{(commission * 0.12):F2}");
                        }
                        else
                            Console.WriteLine("error");
                    }
                    break;

                case "Varna":
                    {
                        if (commission >= 0 && commission <= 500)
                        {
                            Console.WriteLine($"{(commission * 0.045):F2}");
                        }

                        else if (commission > 500 && commission <= 1000)
                        {
                            Console.WriteLine($"{(commission * 0.075):F2}");
                        }

                        else if (commission > 1000 && commission <= 10000)
                        {
                            Console.WriteLine($"{(commission * 0.1):F2}");
                        }

                        else if (commission > 10000)
                        {
                            Console.WriteLine($"{(commission * 0.13):F2}");
                        }
                        else
                            Console.WriteLine("error");
                    }
                    break;

                case "Plovdiv":
                    {
                        if (commission >= 0 && commission <= 500)
                        {
                            Console.WriteLine($"{(commission * 0.055):F2}");
                        }

                        else if (commission > 500 && commission <= 1000)
                        {
                            Console.WriteLine($"{(commission * 0.08):F2}");
                        }

                        else if (commission > 1000 && commission <= 10000)
                        {
                            Console.WriteLine($"{(commission * 0.12):F2}");
                        }

                        else if (commission > 10000)
                        {
                            Console.WriteLine($"{(commission * 0.145):F2}");
                        }
                        else
                            Console.WriteLine("error");
                    }
                    break;

                default: Console.WriteLine("error"); break;
            }
        }
    }
}
