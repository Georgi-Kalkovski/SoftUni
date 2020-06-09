using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            string text = Console.ReadLine();

            while (text.Contains(word))
            {
                text = text.Replace(word, null);
            }

            Console.WriteLine(text);
        }
    }
}
