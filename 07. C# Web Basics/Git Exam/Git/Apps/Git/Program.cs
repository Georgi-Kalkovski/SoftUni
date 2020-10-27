namespace Git
{
    using System.Threading.Tasks;
    using Git.Data;
    using SUS.MvcFramework;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            CreateDatabase(false);
            await Host.CreateHostAsync(new Startup());
        }

        public static void CreateDatabase(bool isTrue)
        {
            if (isTrue)
            {
                var context = new ApplicationDbContext();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
