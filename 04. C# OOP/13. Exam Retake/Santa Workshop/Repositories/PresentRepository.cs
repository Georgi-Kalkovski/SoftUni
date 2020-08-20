using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private readonly List<IPresent> list;
        public PresentRepository()
        {
            this.list = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => this.list.AsReadOnly();

        public void Add(IPresent model)
        {
            list.Add(model);
        }

        public IPresent FindByName(string name)
        {
            foreach (var dwarf in list)
            {
                if (dwarf.Name == name)
                {
                    return dwarf;
                }
            }

            return null;
        }

        public bool Remove(IPresent model)
        {
            if (list.Contains(model))
            {
                list.Remove(model);
                return true;
            }
            return false;
        }
    }
}
