namespace InterfacesAndAbstraction.Contracts
{
    using InterfacesAndAbstraction.Enums;

    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
