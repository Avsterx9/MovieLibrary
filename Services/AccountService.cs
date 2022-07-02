using Microsoft.AspNetCore.Identity;
using MovieLibrary.DtoModels;
using MovieLibrary.Entities;

namespace MovieLibrary.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly MovieDbContext dbContext;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly AuthenticationSettings authSettings;

        public AccountService(MovieDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authSettings)
        {
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
            this.authSettings = authSettings;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            Console.WriteLine("elo");
        }
    }
}
