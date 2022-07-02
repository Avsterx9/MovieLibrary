using MovieLibrary.DtoModels;

namespace MovieLibrary.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }

    public class AccountService : IAccountService
    {
        public void RegisterUser(RegisterUserDto dto)
        {
            Console.WriteLine("elo");
        }
    }
}
