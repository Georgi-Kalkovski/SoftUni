namespace MuOnline
{
    using System;
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();
            IEngine engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            throw new NotImplementedException();
        }
    }
}
