using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Three_brothers
{
    class Program
    {
        static void Main(string[] args)
        {

            double brotherA = double.Parse(Console.ReadLine());
            double brotherB = double.Parse(Console.ReadLine());
            double brotherC = double.Parse(Console.ReadLine());
            // vuvejdae na konzolata chasovete na sinovete A,B i C za pochistvane
            double fatherD = double.Parse(Console.ReadLine());
            // vuvejdame chasovete na bashtata D za ribolov

            double brothersTime =1/(1/brotherA + 1/brotherB + 1/brotherC) * 1.15;
            // namirame obshtoto vreme za pochistvane na sinovete minus pochivkata
            double timeLeft = fatherD - brothersTime;
            // vadim vremeto za ribolov na bashtata sprqmo pochistvaneto na sinovete
            Console.WriteLine($"Cleaning time: {brothersTime:F2}");
            // vadim na konzolata vremeto na sinovete do vtoriq znak sled desetichnata zapetaq

            if (fatherD > brothersTime)
            // ako vremeto na bashtata e po-golqmo ot vremeto za pochistvan na sinovete
            {
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(timeLeft)} hours.");
                // vadim na konzolata, che iznenadata shte se poluchi i ostavastoto bonus vreme
                //izpolzvame Math.Floor za zakruglqne na vremeto
            }

            else if (fatherD < brothersTime)
            // ako vremeto za ribolov na bashtata e po-malko ot vremeto za pochistvane na sinovete
            {
                timeLeft = Math.Abs(timeLeft);
                // prevrushtame otricatelnoto vreme v polojitelno, za da go polzvame v konzolata
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(timeLeft)} hours.");
                // vadim na konzolata, che iznenadata nqma da se poluchi i nujnoto vreme za iznenada
                //izpolzvame Math.Ceiling za zakruglqne na vremeto
            }

        }
    }
}
