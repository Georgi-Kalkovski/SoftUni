using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Problem_04.Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            // obtain list size
            List<int> listSize =
                Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string option = Console.ReadLine();

            long min = listSize.Min();
            long max = listSize.Max();

            List<long> list = new List<long>();

            // list populate
            for (long i = min; i <= max; i++)
            {
                list.Add(i);
            }

            // declare predictate
            Predicate<long> even = x => { return x % 2 == 0; };
            Predicate<long> odd = x => { return x % 2 != 0; };

            //output processing
            List<long> result = new List<long>();
            if (option == "odd")
            {
                result = list.FindAll(odd);
            }
            else
            {
                result = list.FindAll(even);
            }

            // result print
            Console.WriteLine(string.Join(" ", result));


        }
    }
}