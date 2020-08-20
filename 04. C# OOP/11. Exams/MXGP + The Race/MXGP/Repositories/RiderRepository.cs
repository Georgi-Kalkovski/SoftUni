
using MXGP.Models.Riders.Contracts;

namespace MXGP.Repositories
{
    public class RiderRepository : BasicRepository<IRider>
    {
        public override IRider GetByName(string name)
        {
            return this.list.Find(x => x.Name == name);
        }
    }
}
