using System;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}