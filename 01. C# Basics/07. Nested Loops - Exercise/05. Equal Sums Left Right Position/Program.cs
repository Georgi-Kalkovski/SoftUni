using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Equal_Sums_Left_Right_Position
{
    class Program
    {
        static void Main(string[] args)
        {

            var lowerNumber = Console.ReadLine();
            var higherNumber = Console.ReadLine();
            int left = 0;
            int right = 0;
            int middle = 0;

            for (int i = int.Parse(lowerNumber); i <= int.Parse(higherNumber); i++)
            {
                var currentDigit = i.ToString();

                left = (int)Char.GetNumericValue(currentDigit[0]) + (int)Char.GetNumericValue(currentDigit[1]);
                right = (int)Char.GetNumericValue(currentDigit[3]) + (int)Char.GetNumericValue(currentDigit[4]);
                middle = (int)Char.GetNumericValue(currentDigit[2]);
            
                if (left == right)
                {
                    Console.Write(i + " ");
                }
				
                else if (left != right)
                {
                    if (left < right)
                    {
                        left += middle;
						
                        if (left == right)
                        {
                            Console.Write(i + " ");
                        }
						
                        else continue;
                    }
					
                    else if (left > right)
                    {
                        right += middle;
						
                        if (left == right)
                        {
                            Console.Write(i + " ");
                        }
						
                        else continue;
                    }
                }
            }
        }
    }
}
