using System.Collections.Generic;
using System.Linq;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public abstract class BasicRepository<T> : IRepository<T>
    {
        protected List<T> list;

        protected BasicRepository()
            {
            this.list = new List<T>();
            }
        public void Add(T model)
        {
            this.list.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.list.AsReadOnly();
        }

        public abstract T GetByName(string name);
        
        public bool Remove(T model)
        {
            return this.list.Remove(model);
        }
    }
}
