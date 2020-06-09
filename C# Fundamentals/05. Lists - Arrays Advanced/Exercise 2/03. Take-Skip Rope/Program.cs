using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeSkip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptedMessage = Console.ReadLine();
            var numberList = new List<int>();
            var charList = new List<char>();

            foreach (var symbol in encryptedMessage)
            {
                if (char.IsDigit(symbol))
                {
                    int num = int.Parse(symbol.ToString());
                    numberList.Add(num);
                }
				
                else
                {
                    charList.Add(symbol);
                }
            }
			
            var takeList = new List<int>();
            var skipList = new List<int>();

            for (int index = 0; index < numberList.Count; index++)
            {
                if (index % 2 == 0)
                {
                    takeList.Add(numberList[index]);
                }
				
                else
                {
                    skipList.Add(numberList[index]);
                }
            }

            string result = null;

            var total = 0;
			
            for (int index = 0; index < skipList.Count; index++)
            {
                int skipCount = skipList[index];
                int takeCoun = takeList[index];
                result += new string(charList.Skip(total).Take(takeCoun).ToArray());
                total += skipCount + takeCoun;
            }
			
            Console.WriteLine(result);
        }
    }
}