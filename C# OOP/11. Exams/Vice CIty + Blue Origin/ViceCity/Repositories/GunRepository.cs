using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private Dictionary<string, IGun> collectionOfGuns;

        public GunRepository()
        {
            this.collectionOfGuns = new Dictionary<string, IGun>();
        }
        public IReadOnlyCollection<IGun> Models => this.collectionOfGuns.Values.ToList().AsReadOnly();

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException("Gun cannot be null");
            }
            if (this.collectionOfGuns.ContainsKey(model.Name))
            {
                throw new ArgumentException($"Gun {model.Name} already exists!");
            }
            this.collectionOfGuns.Add(model.Name, model);
        }

        public IGun Find(string name)
        {
            IGun gunFound = null;

            if (this.collectionOfGuns.ContainsKey(name))
            {
                gunFound = this.collectionOfGuns[name];
            }

            return gunFound;
        }

        public bool Remove(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException("Gun cannot be null");
            }
            return this.collectionOfGuns.Remove(model.Name);
        }
    }
}
