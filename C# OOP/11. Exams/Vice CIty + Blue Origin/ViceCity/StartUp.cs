using ViceCity.Core;
using ViceCity.Core.Contracts;
using System;

namespace ViceCity
{
    public class StartUp
    {
        IEngine engine;
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
