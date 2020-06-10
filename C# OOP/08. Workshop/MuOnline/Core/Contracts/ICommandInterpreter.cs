namespace MuOnline.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] args);
    }
}
