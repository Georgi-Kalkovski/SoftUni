using System;
using System.IO;
using System.Linq;

namespace _04._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileOne = @"G:/C#/03. C# ADVANCED/10.01.19 - Streams, Files and Directories - Lab/04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources/Resources/04. Merge Files/FileOne.txt";
            string fileTwo = @"G:/C#/03. C# ADVANCED/10.01.19 - Streams, Files and Directories - Lab/04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources/Resources/04. Merge Files/FileTwo.txt";
            string output = @"G:/C#/03. C# ADVANCED/10.01.19 - Streams, Files and Directories - Lab/04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources/Resources/04. Merge Files/Output.txt";

            string[] fileOneLines = File.ReadAllLines(fileOne);
            string[] fileTwoLines = File.ReadAllLines(fileTwo);

            string[] allLines = fileOneLines.Concat(fileTwoLines).ToArray();

            Array.Sort(allLines);

            File.WriteAllLines(output, allLines);
        }
    }
}
