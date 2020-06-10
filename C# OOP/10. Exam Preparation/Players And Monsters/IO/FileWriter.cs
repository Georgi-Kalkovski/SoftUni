using System;
using System.IO;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.IO
{
    public class FileWriter : IWriter
    {
        private FileStream fs;
        private StreamWriter sw;

        public FileWriter()
        {
            this.fs = new FileStream("./output.txt", FileMode.OpenOrCreate, FileAccess.Write);
            this.sw = new StreamWriter(fs);

            sw.AutoFlush = true;

            Console.SetOut(sw);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}