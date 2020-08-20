using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Slice_a_File
{
    class Program
    {
       
        static void Main(string[] args)
        {
            string fileDirectory = @"G:\C#\03. C# ADVANCED\10.01.19 - Streams, Files and Directories - Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\05. Slice File\sliceMe.txt";
            string directory = @"G:\C#\03. C# ADVANCED\10.01.19 - Streams, Files and Directories - Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\05. Slice File\";

            var list = new List<string>();
            var fileSuffix = 0;

            using (var file = File.OpenRead(fileDirectory))

            using (var reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    list.Add(reader.ReadLine());

                    if (list.Count >= 35)
                    {
                        File.WriteAllLines(directory + $"text-{++fileSuffix}.txt", list);
                        list = new List<string>();
                    }
                }
            }

            File.WriteAllLines(directory + $"text-{++fileSuffix}.txt", list);
        }
    }
}
