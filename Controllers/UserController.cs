using Microsoft.AspNetCore.Mvc;
using project_renault.NovaPasta;
using project_renault.Services;

namespace project_renault.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> doLogin(UserDTO userDTO) 
        {
            var user = await userService.doLogin(userDTO);
            if (user == null)
            {
                return NotFound(user);
            }
            return Ok(user);
        }
    }
}
