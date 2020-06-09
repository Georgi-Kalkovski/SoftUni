using System;
using System.Linq;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string text = Console.ReadLine();

                if (text == "end")
                {
                    break;
                }
				
                string reversedText = null;

                for(int i = text.Length-1; i >= 0;i--)
                {
                    reversedText+=text[i];
                }

                Console.WriteLine($"{text} = {reversedText}");
            }
        }
    }
}
