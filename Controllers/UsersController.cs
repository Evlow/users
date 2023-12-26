using Microsoft.AspNetCore.Mvc;
using userMicroservice.Model;
using userMicroservice.Services.Interface;
using userMicroservice.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace userMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult> UserList()
        {
            try
            {
                var users = await _userService.GetUserList();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                });
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserByIdAsync(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult> CreateUserAsync(User user)
        {
            try
            {
                var userAdded = await _userService.CreateUserAsync(user);
                return Ok(userAdded);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                });
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync(User user, int userId)
        {
            try
            {
                var userUpdated = await _userService.UpdateUserAsync(user, userId);
                return Ok(userUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                });
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(int userId)
        {
            try
            {
                var userDeleted = await _userService.DeleteUserAsync(userId);
                return Ok(userDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                });
            }
        }
    }
}
