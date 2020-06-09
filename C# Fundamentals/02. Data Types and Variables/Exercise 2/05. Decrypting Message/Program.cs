using System;

namespace _05._Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {

            int key = int.Parse(Console.ReadLine());            
            int n = int.Parse(Console.ReadLine());              
            string word = string.Empty;                         

            for (int i = 0; i < n; i++)                         
            {                                                 
                char character = char.Parse(Console.ReadLine());
                character += (char)key;                         
                word += character;                              
            }                                                   

            Console.WriteLine(word);                            

        }
    }
}
