namespace SantaWorkshop
{
    using System;

    using SantaWorkshop.Core;
    using SantaWorkshop.Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
