using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly List<IDwarf> list;
        public DwarfRepository()
        {
            this.list = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => this.list.AsReadOnly();

        public void Add(IDwarf model)
        {
            list.Add(model);
        }

        public IDwarf FindByName(string name)
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

        public bool Remove(IDwarf model)
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
