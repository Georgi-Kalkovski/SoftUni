using System.Collections.Generic;
using System.Linq;
using System.Xml.Xsl;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        public override IMotorcycle GetByName(string name)
        {
            return models.Find(x => x.Model == name);
        }
    }
}
