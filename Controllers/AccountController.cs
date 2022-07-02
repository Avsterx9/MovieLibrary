using Microsoft.AspNetCore.Mvc;
using MovieLibrary.DtoModels;
using MovieLibrary.Services;

namespace MovieLibrary.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IAccountService accountService { get; }

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult<String> RegisterUser(RegisterUserDto registerDto)
        {
            accountService.RegisterUser(registerDto);
            return Ok();
        }
    }
}
