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
            // vuvejdame na konzolata figura
            double area = 0;
            // stoinost za durjne na lice na figura

            switch (figure)
            // "switch" na figura
            {

                case "square":
                // sluchai, ako figurata e kvadrat
                    {
                        double a = double.Parse(Console.ReadLine());
                        // vuvejdame na konzolata strana "a"
                        area = a * a;
                        // namirame liceto kato umnojim stranite "a" po "a"
                        break;
                        // slagame krai na "switch"
                    }

                case "rectangle":
                    // sluchai, ako figurata e pravougulnik
                    {
                        double a = double.Parse(Console.ReadLine());
                        // vuvejdame na konzolata strana "a"
                        double b = double.Parse(Console.ReadLine());
                        // vuvejdame na konzolata strana "b"
                        area = a * b;
                        // namirame liceto kato umnojim stranite "a" po "b"
                        break;
                        // slagame krai na "switch"
                    }

                case "circle":
                    // sluchai, ako figurata e krug
                    {
                        double a = double.Parse(Console.ReadLine());
                        // vuvejdame na konzolata radius "a"
                        area = Math.PI * (a * a);
                        // namirame liceto kato umnojim dva puti radiusa po PI
                        break;
                        // slagame krai na "switch"
                    }

                case "triangle":
                    // sluchai, ako figurata e triugulnik
                    {
                        double a = double.Parse(Console.ReadLine());
                        // vuvejdame na konzolata radius "a"
                        double b = double.Parse(Console.ReadLine());
                        // vuvejdame na konzolata radius "b"
                        area = a * b / 2;
                        // namirame liceto kato umnojim stranite "a" po "b" deleno na 2
                        break;
                        // slagame krai na "switch"
                    }
            }
            Console.WriteLine($"{area:F3}");
            // vadim na konzolata liceto n figurata do tretiq znak sled desetichnata zapetaq
        }
    }
}