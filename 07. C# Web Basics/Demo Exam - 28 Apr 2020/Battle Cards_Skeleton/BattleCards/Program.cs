using SIS.MvcFramework;
using System;
using System.Threading.Tasks;

namespace BattleCards
{
    public static class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
