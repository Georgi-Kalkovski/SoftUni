using Git.Data;
using Git.InputModels;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Git.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string CreateUser(string username, string email, string password)
        {
            var newUser = new User { Username = username, Email = email, Password = HashPassword(password)};
            this.context.Users.Add(newUser);
            this.context.SaveChanges();
            return newUser.Id;
        }

        public string CreateUser(RegisterUserInputModel inputModel)
        {
            return this.CreateUser(inputModel.Username, inputModel.Email, inputModel.Password);
        }

        public string GetUserId(string username, string password)
        {
            return this.context.Users.FirstOrDefault(x => x.Username == username && x.Password == HashPassword(password)).Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !this.context.Users.Any(x => x.Email == email);
        }

        public bool IsEmailValid(string email)
        {
            var emailAttribute = new EmailAddressAttribute();
            return emailAttribute.IsValid(email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !this.context.Users.Any(x => x.Username == username);
        }

        private string HashPassword(string password)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        public bool IsPasswordAvailabe(string password)
        {
            return !this.context.Users.Any(x => x.Password == HashPassword(password));
        }

        public bool DoesUserExist(string username, string password)
        {
            return this.context.Users.Any(x => x.Username == username && x.Password == HashPassword(password));
        }
    }
}
