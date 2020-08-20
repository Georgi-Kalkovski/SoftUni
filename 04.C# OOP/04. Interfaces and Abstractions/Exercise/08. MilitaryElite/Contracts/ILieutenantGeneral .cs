namespace InterfacesAndAbstraction.Contracts
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral : IPrivate
    {
        public Dictionary<int, IPrivate> Privates { get; }
    }
}
