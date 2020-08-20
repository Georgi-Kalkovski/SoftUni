using MXGP.Models.Races.Contracts;

namespace MXGP.Repositories
{
    public class RaceRepository : BasicRepository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return this.list.Find(x => x.Name == name);
        }
    }
}
