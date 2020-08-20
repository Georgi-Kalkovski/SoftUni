namespace InterfacesAndAbstraction.Contracts
{
    using InterfacesAndAbstraction.Enums;

    public interface IMission
    {
        public string CodeName { get; }

        public State State { get; }

        public void CompleteMission();
    }
}
