using System;
using System.IO;

namespace _01._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathInput = @"G:/C#/03. C# ADVANCED/10.01.19 - Streams, Files and Directories - Lab/04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources/Resources/01. Odd Lines/Input.txt";
            string pathOutput = @"G:/C#/03. C# ADVANCED/10.01.19 - Streams, Files and Directories - Lab/04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources/Resources/01. Odd Lines/Output.txt";

            string[] inputLines = File.ReadAllLines(pathInput);
            string[] outputLines = new string[inputLines.Length / 2];

            for (int i = 0; i < inputLines.Length; i++)
            {
                if (i % 2 != 0)
                {
                    outputLines[i / 2] = inputLines[i];
                }
            }
            File.WriteAllLines(pathOutput, outputLines);
        }
    }
}
