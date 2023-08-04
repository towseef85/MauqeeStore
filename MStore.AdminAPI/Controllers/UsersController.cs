using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.AuthenticationBL;
using MStore.Application.Dtos.AppUsersDtos;
using System.Security.Claims;

namespace MStore.AdminAPI.Controllers
{

    public class UsersController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            return HandleResult(await Mediator.Send(new UserLogin.Command { Login = loginDto }));
        }

        [HttpGet("CurrentUser")]
        public async Task<ActionResult<GetUserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            return HandleResult(await Mediator.Send(new LoggedInUser.Command { Email = email }));
        }
    }
}
