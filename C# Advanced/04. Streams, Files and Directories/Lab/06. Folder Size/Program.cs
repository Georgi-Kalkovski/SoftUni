using System;
using System.IO;
using System.Linq;

namespace _06._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = @"G:\C#\03. C# ADVANCED\10.01.19 - Streams, Files and Directories - Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\06. Folder Size\TestFolder";
            string output = @"G:\C#\03. C# ADVANCED\10.01.19 - Streams, Files and Directories - Lab\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\06. Folder Size\Megabytes.txt";

            var files = Directory.GetFiles(directory);

            long sum = 0;

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }
            
            var sumInMB = (sum / 1024.0) / 1024.0;

            File.WriteAllText(output, sumInMB.ToString());
        }
    }
}
