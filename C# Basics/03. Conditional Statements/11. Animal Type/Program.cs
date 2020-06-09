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
            // vuvejdame jivotno na konzolata

            if (animal != "dog" && animal != "crocodile" && animal != "tortoise" && animal != "snake")
            // ako jivotnoto ne e v spisuka ot dadeni jivotni
            {
                Console.WriteLine("unknown");
                // vadim na konzolata, che jivotnoo e nepoznato
            }

            else
            // ako li ne (jivotnoto se znae)
            {
                switch (animal)
                // pravim "switch" sus sluchai
                {
                    case "dog": Console.WriteLine("mammal"); break;
                    case "crocodile": Console.WriteLine("reptile"); break;
                    case "tortoise": Console.WriteLine("reptile"); break;
                    case "snake": Console.WriteLine("reptile"); break;
                    // pri sluchai na dadeno jivotno
                    // vadim na konzolata suotvetno dali to e bozainik ili vlechugo
                    // slagame krai na "switch" s "break"
                }
            }

        }
    }
}
