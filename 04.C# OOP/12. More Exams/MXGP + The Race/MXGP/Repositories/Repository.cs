using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected List<T> models;

        public Repository()
        {
            models = new List<T>();
        }

        public void Add(T model)
        {
            models.Add(model);
        }

        public bool Remove(T model)
        {
            return models.Remove(model);
        }

        public abstract T GetByName(string name);

        public IReadOnlyCollection<T> GetAll()
        {
            return models.AsReadOnly();
        }
    }
}
