namespace SantaWorkshop.Repositories.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(T model);

        bool Remove(T model);

        T FindByName(string name);
    }
}
