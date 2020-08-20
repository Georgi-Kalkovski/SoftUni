using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> list;
        public DecorationRepository()
        {
            this.list = new List<IDecoration>();
        }
        public int Count => this.list.Count;

        public IReadOnlyCollection<IDecoration> Models => this.list.AsReadOnly();

        public void Add(IDecoration model)
        {
            list.Add(model);
        }

        public bool Remove(IDecoration model)
        {
            if (list.Contains(model))
            {
                list.Remove(model);
                return true;
            }
            return false;
        }

        public IDecoration FindByType(string type)
        {
            foreach (var decoration in list)
            {
                if (decoration.GetType().Name == type)
                {
                    return decoration;
                }
            }

            return null;

            //list.Where(x => x.GetType() == Type.GetType(type)).FirstOrDefault()
        }
    }
}
