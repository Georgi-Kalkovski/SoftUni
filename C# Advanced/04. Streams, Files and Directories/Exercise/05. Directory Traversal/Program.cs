using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace _5___Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            //THE RESULT WILL BE PRINTED IN "report.txt" ON YOUR DESKTOP



            var zipPath = "DirectoryTraversalDemo.zip";  //giving path for zipped files 
            var unzippedPath = "./";                    //path to the unzipped files

            if (Directory.Exists("../DirectoryToCheck"))  //if the folder exists, delete it (иначе гърми exception :D ) 
            {
                Directory.Delete("../DirectoryToCheck", true); //true is a "must" if you try to delete non-empty folder
            }

            ZipFile.ExtractToDirectory(zipPath, unzippedPath);

            var dictWithAllInfo = new Dictionary<string, Dictionary<string, double>>();

            var di = new DirectoryInfo("directoryToCheck");
            var allFiles = di.GetFiles();

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            desktopPath += "\\report.txt";  //we need to append "\\" in order to use this path. 

            //adding all the files from the directory to the dictionary
            foreach (var file in allFiles)
            {
                var extension = file.Extension;

                if (!dictWithAllInfo.ContainsKey(extension))
                {
                    dictWithAllInfo.Add(extension, new Dictionary<string, double>());
                }

                dictWithAllInfo[extension].Add(file.Name, file.Length / 1000D);
            }

            dictWithAllInfo = dictWithAllInfo.OrderByDescending(x => x.Value.Count)
                          .ThenBy(x => x.Key)
                          .ToDictionary(x => x.Key, y => y.Value);

            using (var writer = new StreamWriter(desktopPath))
            {
                foreach (var extension in dictWithAllInfo)
                {
                    //  Console.WriteLine(extension.Key);
                    writer.WriteLine(extension.Key);

                    foreach (var doc in extension.Value.OrderBy(x => x.Value))
                    {
                        // Console.WriteLine($"{doc.Key} - {doc.Value:f3}kb");
                        writer.WriteLine($"{doc.Key} - {doc.Value:f3}kb");
                    }
                }
            }
        }
    }
}