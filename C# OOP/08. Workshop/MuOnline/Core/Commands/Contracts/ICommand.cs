namespace MuOnline.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(string[] inputArgs);
    }
}
