using Git.InputModels;
using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Register()
        {
            if(this.IsUserSignedIn() == true)
            {
                return this.Error("Only logged off users can register.");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserInputModel inputModel)
        {
            if (this.IsUserSignedIn() == true)
            {
                return this.Error("Only logged off users can register.");
            }

            if(string.IsNullOrEmpty(inputModel.Username) || inputModel.Username.Length < 5 || inputModel.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters long.");
            }

            if (string.IsNullOrEmpty(inputModel.Email) || this.userService.IsEmailValid(inputModel.Email) == false) 
            {
                return this.Error("Email is invalid.");
            }

            if (string.IsNullOrEmpty(inputModel.Password) || inputModel.Password.Length < 6 || inputModel.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters long.");
            }

            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Error("Password and confirm password do not match.");
            }

            if(this.userService.IsEmailAvailable(inputModel.Email) == false)
            {
                return this.Error("Email is already taken.");
            }

            if (this.userService.IsUsernameAvailable(inputModel.Username) == false)
            {
                return this.Error("Username is already taken.");
            }

            this.userService.CreateUser(inputModel);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn() == true)
            {
                return this.Error("Only logged off users can login.");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserInputModel inputModel)
        {
            if (this.IsUserSignedIn() == true)
            {
                return this.Error("Only logged off users can login.");
            }

            if(this.userService.IsUsernameAvailable(inputModel.Username) == true)
            {
                return this.Error("User with this username doesn't exist.");
            }

            if (this.userService.IsPasswordAvailabe(inputModel.Password) == true)
            {
                return this.Error("User with this password doesn't exist.");
            }

            if(this.userService.DoesUserExist(inputModel.Username, inputModel.Password) == false)
            {
                return this.Error("User with this password and username doesn't exist.");
            }

            var userId = this.userService.GetUserId(inputModel.Username, inputModel.Password);
            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            if(this.IsUserSignedIn() == false)
            {
                return this.Error("Only logged in users can logout.");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
