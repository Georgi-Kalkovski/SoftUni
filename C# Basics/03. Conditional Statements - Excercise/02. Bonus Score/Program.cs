using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {

            double points = double.Parse(Console.ReadLine());
            // vuvejdame tochki na konzolata
            double bonusPoints = 0;
            // mqsto za skladirane na bonus tochkite

            if (points <= 100)
            // ako tochkite sa pod 101
            {
                bonusPoints += 5;
                // dobavqme +5 kum bonus tochkite

                if (points %2 == 0)
                // ako tochkite sa chetni
                {
                    bonusPoints += 1;
                    // dobavqme +1 kum bonus tochkite
                }

                else if (points %5 == 0)
                // ako tockkite se delqt na 5
                {
                    bonusPoints += 2;
                    // dobavqme +2 kum bonus tochkite
                }
                points = points + bonusPoints;
                // subirame tochkite s bonus tochkite, za da namerim obshto kolko tochki sme subrali
            }

            else if (points > 100 && points <= 1000)
            // ako tochkite sa mejdu 101 i 1000 vkliuchitelno
            {
                bonusPoints = points * 0.20;
                // dobavqme kum bonus tochkite 20% ot tochkite

                if (points % 2 == 0)
                // ako tochkite sa chetni
                {
                    bonusPoints += 1;
                    // dobavqme +1 kum bonus tochkite
                }

                else if (points % 5 == 0)
                // ako tochkite se delqt na 5
                {
                    bonusPoints += 2;
                    // dobavqme +2 kum bonus tochkite
                }
                points = points + bonusPoints;
                // subirame tochkite s bonus tochkite, za da namerim obshto kolko tochki sme subrali
            }

            else if (points > 1000)
            // ako tochkite sa nad 1000
            {
                bonusPoints = points * 0.10;
                // dobavqme kum bonus tochkite 10% ot tochkite

                if (points % 2 == 0)
                // ako tochkite sa chetni
                {
                    bonusPoints += 1;
                    // dobavqme +1 kum bonus tochkite
                }

                else if (points % 5 == 0)
                // ako tochkite se delqt na 5
                {
                    bonusPoints += 2;
                    // dobavqme +2 kum bonus tochkite
                }
                points = points + bonusPoints;
                // subirame tochkite s bonus tochkite, za da namerim obshto kolko tochki sme subrali
            }

            Console.WriteLine(bonusPoints);
            // pokazva se na konzolata bonus tochkite
            Console.WriteLine(points);
            // pokazva se na konzolata bonus tochkite + tochkite
        }
    }
}
