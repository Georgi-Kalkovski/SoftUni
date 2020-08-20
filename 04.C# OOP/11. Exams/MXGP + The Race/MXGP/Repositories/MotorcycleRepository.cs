using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : BasicRepository<IMotorcycle>
    {
        public override IMotorcycle GetByName(string name)
        {
            return this.list.Find(x => x.Model == name);
        }
    }
}
