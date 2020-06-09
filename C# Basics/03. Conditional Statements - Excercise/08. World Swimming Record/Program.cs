using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {

            double record = double.Parse(Console.ReadLine());
            // vuvejdame na konzolata rekord
            double length = double.Parse(Console.ReadLine());
            // vuvejdame duljinata za pluvane
            double time = double.Parse(Console.ReadLine());
            // vuvejdame vremeto, koeto se e pluvalo

            double lengthAndTime = length * time;
            // namirame opita kato umnojim duljinata po vremeto
            double timeTrue = length / 15;
            // namirame istinskoto vreme kato razdelim duljinata na 15
            int metersRound = (int)timeTrue;
            // zakruglqme metrite na cqlo chislo
            double metersLost = metersRound * 12.5;
            // namirame zagubenite metri
            double timeRound = lengthAndTime + metersLost;
            // namirame tochnoto vreme za opita kato suberem duljinata i vremeto zaedno s dopulnitelnoto vreme
            double recordFailed = timeRound - record;
            // namirame stoinostta n provaleniq rekord kato izvadim ot opita rekorda

            if (record <= timeRound)
            // ako rekorda e po-maluk ot opita
            {
                Console.WriteLine($"No, he failed! He was {recordFailed:F2} seconds slower.");
                // pishem, che se e provalil i pokazvame s kolko vreme se razminava ot rekorda
            }

            else if (record > timeRound)
            // ako rekorda e po-golqm ot opita
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {timeRound:F2} seconds.");
                // pishem che ima nov rekord i vuvejdame noviq rekord
            }

        }
    }
}
