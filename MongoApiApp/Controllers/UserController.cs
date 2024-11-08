using Microsoft.AspNetCore.Mvc;
using MongoApiApp.Data;
using MongoApiApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MongoContext _mongoContext;

        public UsersController()
        {
            _mongoContext = new MongoContext();
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _mongoContext.GetAllUsersAsync();
            return Ok(users);
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            var createdUser = await _mongoContext.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUsers), new { id = createdUser.Id }, createdUser);
        }
    }
}
