using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Number_1_9_to_Text
{
    class Program
    {
        static void Main(string[] args)
        {

            double number = double.Parse(Console.ReadLine());
            // pishem na konzolata chislo

            if (number > 9)
            // ako chisloto e nad 9
            {
                Console.WriteLine("number too big");
                // vadim na konzolata, che chisloto e tvurde golqmo
                return;
                // slagame krai na programta
            }

            switch (number)
            // ako chisloto e po-malko ot 10, izpolzvame "switch"
            {
                case 1: Console.WriteLine("one"); break;
                case 2: Console.WriteLine("two"); break;
                case 3: Console.WriteLine("three"); break;
                case 4: Console.WriteLine("four"); break;
                case 5: Console.WriteLine("five"); break;
                case 6: Console.WriteLine("six"); break;
                case 7: Console.WriteLine("seven"); break;
                case 8: Console.WriteLine("eight"); break;
                case 9: Console.WriteLine("nine"); break;
                // pri vseki red imame sluchai ot 1 do 9
                // suotvetno na vsqka cifra vadim na konzolata kak se pishe s bukvi
                // slagame krai na sluchaq s "break"
            }
        }
    }
}
