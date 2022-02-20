using Microsoft.AspNetCore.Mvc;
using Todoonboard_api.Models;
using Todoonboard_api.Services;
using Todoonboard_api.Helpers;
using Todoonboard_api.InfoModels;

namespace Todoonboard_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

    [HttpPost("create")]



        public IActionResult create(UserRequest userRequest)

        {

            var user = _userService.create(userRequest);

            if(user == null) return BadRequest(user);

            return Ok(user);

        }
    }
}