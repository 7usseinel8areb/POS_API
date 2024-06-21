

using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;
using PointofSalesApi.DTO.AppUsersDTO;
using PointofSalesApi.Services.AppUsersService;

namespace PointofSalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IAppUserService appUserService;
                                                                                                                                                
        public ApplicationUserController(IAppUserService appUserService)
        {
            this.appUserService = appUserService;
        }

        [HttpGet]
        [Authorize(Roles ="Cashier")]
        public async Task<IActionResult> GetAppUsers()
        {
            var users = await appUserService.GetAppUsers();
            return Ok(users);
        }

        [HttpGet("{userName}",Name ="GetOneAppUserRoute")]
        public async Task<IActionResult> GetSingleAppUser([EmailAddress]string userName)
        {
            var user = await appUserService.GetUser(userName);
            if (user == null)
            {
                return NotFound($"User with username {userName} was not found!");
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddAppUser(AddAppUserDTO addAppUserDTO)
        {
            if(ModelState.IsValid)
            {
                await appUserService.CreateUser(addAppUserDTO);
                return Created();
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var (token,expiration) = await appUserService.LogIn(loginDTO);
                    return Ok(new { token, expiration });
                }
                catch (UnauthorizedAccessException)
                {
                    return Unauthorized();
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            var result = await appUserService.DeleteUser(userName);
            if(result == true)
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpPost("User/{email}/RoleName")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> AddRoleToUser([EmailAddress]string email,UserRolesDTO role)
        {
            (int statuscode,string message) = await appUserService.AddRole(email, role);
            return StatusCode(statuscode, new {Message = message });
        }
    }
}
