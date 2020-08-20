using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Problem_6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream(@"output.zip", FileMode.Create))
            using (ZipArchive arch = new ZipArchive(fs, ZipArchiveMode.Create))
            {
                arch.CreateEntryFromFile(@"../../../../CopyMe.png", "CopyMe1.png");
            }

            ZipFile.ExtractToDirectory(@"output.zip", @"../../../../");
        }
    }
}