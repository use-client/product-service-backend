using Microsoft.AspNetCore.Mvc;
using ProductService.DapperRepositories;
using ProductService.Models;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(SuccessResponse< IEnumerable<User>>.Create(users));
        }
    }
}