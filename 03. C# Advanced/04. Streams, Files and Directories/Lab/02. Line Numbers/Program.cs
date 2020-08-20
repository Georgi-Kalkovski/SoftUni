using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathInput = @"G:/C#/03. C# ADVANCED/10.01.19 - Streams, Files and Directories - Lab/04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources/Resources/02. Line Numbers/Input.txt";
            string pathOutput = @"G:/C#/03. C# ADVANCED/10.01.19 - Streams, Files and Directories - Lab/04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources/Resources/02. Line Numbers/Output.txt";

            string[] inputLines = File.ReadAllLines(pathInput);
            string[] outputLines = new string[inputLines.Length];

            for(int i = 0;i<inputLines.Length;i++)
            {
                outputLines[i] = $"{i + 1}. " + inputLines[i];
            }

            File.WriteAllLines(pathOutput, outputLines);
        }
    }
}
