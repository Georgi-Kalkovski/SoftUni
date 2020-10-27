using Git.InputModels;

namespace Git.Services
{
    public interface IUserService
    {
        string CreateUser(string username, string email, string password);
        string CreateUser(RegisterUserInputModel inputModel);

        bool IsEmailAvailable(string email);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);
        bool IsPasswordAvailabe(string password);
        bool DoesUserExist(string username, string password);
        bool IsEmailValid(string email);
    }
}
