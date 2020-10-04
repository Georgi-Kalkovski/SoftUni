using SUS.MvcFramework;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup(), 80);
        }
    }
}