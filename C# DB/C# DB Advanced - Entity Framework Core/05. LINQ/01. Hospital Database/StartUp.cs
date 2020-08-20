using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var hospitalContext = new HospitalContext();
            hospitalContext.Database.EnsureDeleted();
            hospitalContext.Database.EnsureCreated();
        }
    }
}
