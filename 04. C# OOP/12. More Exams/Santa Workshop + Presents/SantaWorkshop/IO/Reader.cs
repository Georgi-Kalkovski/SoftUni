namespace SantaWorkshop.IO
{
    using System;

    using SantaWorkshop.IO.Contracts;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}