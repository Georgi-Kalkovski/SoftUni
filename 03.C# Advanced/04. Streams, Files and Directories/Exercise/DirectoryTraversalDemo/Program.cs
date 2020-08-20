using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StreamsExercise
{
    public class Program
    {
        public static void Main()
        {
            var filesByExtension = new Dictionary<string, Dictionary<string, long>>();

            var files = GetAllFilesFromDirectory(Environment.CurrentDirectory);

            //var files = Directory.GetFiles(Environment.CurrentDirectory, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var extension = file.Extension;

                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension.Add(extension, new Dictionary<string, long>());
                }

                filesByExtension[extension].Add(file.Name, file.Length);
            }

            var sortedFilesByExtension = filesByExtension
                .OrderByDescending(e => e.Value.Count)
                .ThenBy(e => e.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            using (var streamWriter = new StreamWriter("../../../report.txt"))
            {
                foreach (var extension in sortedFilesByExtension)
                {
                    streamWriter.WriteLine(extension.Key);

                    var currentFiles = extension.Value
                        .OrderBy(f => f.Value)
                        .ToDictionary(x => x.Key, x => x.Value);

                    foreach (var file in currentFiles)
                    {
                        streamWriter.WriteLine($"--{file.Key} - {(file.Value / 1000.0):F3}kb");
                    }
                }
            }
        }

        private static List<FileInfo> GetAllFilesFromDirectory(string path)
        {
            var rootDirectory = new DirectoryInfo(path);

            var allFiles = new List<FileInfo>();

            var files = rootDirectory.GetFiles();
            allFiles.AddRange(files);

            var subDirectories = rootDirectory.GetDirectories();

            foreach (DirectoryInfo directory in subDirectories)
            {
                var subFiles = GetAllFilesFromDirectory(directory.FullName);
                allFiles.AddRange(subFiles);
            }

            return allFiles;
        }
    }
}
