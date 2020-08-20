using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfWords = Console.ReadLine()        
                .Split()                                         
                .ToList();                                       

            Random rnd = new Random();                           

            for (int i = 0; i < listOfWords.Count; i++)          
            {
                int firstWord = rnd.Next(0, listOfWords.Count);  
                int secondWord = rnd.Next(0, listOfWords.Count); 

                string changer = listOfWords[firstWord];         
                listOfWords[firstWord] = listOfWords[secondWord];
                listOfWords[secondWord] = changer;               

            }

            Console.WriteLine(string.Join("\n", listOfWords));   
        }
    }
}
