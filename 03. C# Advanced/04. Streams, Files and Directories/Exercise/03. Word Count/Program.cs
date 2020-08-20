using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfWords = File.ReadAllLines("words.txt");
            var text = File.ReadAllText("text.txt");
            var symbols = new[] { '-', ',', '.', '!', '?', ' ' };
            var dict = new Dictionary<string, int>();

            var splittedText = text.Split(symbols);

            for (int i = 0; i < listOfWords.Length; i++)
            {
                int counter = 0;

                foreach (var word in splittedText)
                {
                    if (word.ToLower() == listOfWords[i])
                    {
                        counter++;
                    }
                }

                listOfWords[i] = listOfWords[i] + " - " + counter;
                dict.Add(listOfWords[i], counter);

                File.WriteAllLines("actualResults.txt", listOfWords);
            }

            var sortedDict = dict.OrderByDescending(d => d.Value).ThenByDescending(x=>x.Key).ToDictionary(x=>x.Key, x=>x.Value);

            File.WriteAllLines("expectedResult.txt", sortedDict.Keys);
        }
    }
}
