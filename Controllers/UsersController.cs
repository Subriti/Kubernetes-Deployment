using KubernetesDeployment.Data.Repository;
using KubernetesDeployment.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KubernetesDeployment.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository UserRepository;
        public UsersController(IUserRepository userRepository)
        {
            UserRepository = userRepository ?? throw new ArgumentOutOfRangeException(nameof(userRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return Ok(await UserRepository.GetUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(Guid id)
        {
            var user = await UserRepository.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Users>> Login(string email, string password)
        {
            var user = await UserRepository.Login(email, password);
            if (user == null)
            {
                // return NotFound("Email or Password is incorrect.");
                return StatusCode(400, "Email or Password is incorrect.");
            }
            return Ok(user);
        }
    }
}
