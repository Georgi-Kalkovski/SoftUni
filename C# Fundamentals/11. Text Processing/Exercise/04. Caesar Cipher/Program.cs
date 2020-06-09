using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            var encryptedLine = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                encryptedLine = encryptedLine.Append((char)(line[i]+ 3));
            }

            Console.WriteLine(encryptedLine);
        }
    }
}
