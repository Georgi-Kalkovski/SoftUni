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
            string pathInput = @"G:/C#/03. C# ADVANCED/10.01.19 - Streams, Files and Directories - Lab/04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources/Resources/03. Word Count/text.txt";
            string words = @"G:/C#/03. C# ADVANCED/10.01.19 - Streams, Files and Directories - Lab/04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources/Resources/03. Word Count/words.txt";
            string pathOutput = @"G:/C#/03. C# ADVANCED/10.01.19 - Streams, Files and Directories - Lab/04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources/Resources/03. Word Count/Output.txt";

            var textInput = File.ReadAllText(pathInput);
            var wordsInput = File.ReadAllText(words);
            var output = new Dictionary<string, int>();

            foreach (string word in textInput.Split())
            {
                string newWord = word.ToLower().Trim('-', '.', ',', '?', '!');

                if (wordsInput.Split().ToArray().Contains(newWord.ToString()))
                {
                    if (!output.ContainsKey(newWord))
                    {
                        output.Add(newWord, 1);
                    }

                    else
                    {
                        output[newWord]++;
                    }
                }
            }

            File.Delete(pathOutput);

            var reversedOutput = output.Reverse();

            foreach (var word in reversedOutput)
            {

                File.AppendAllText(pathOutput, $"{word.Key} - {word.Value}\r\n");
            }
        }
    }
}
