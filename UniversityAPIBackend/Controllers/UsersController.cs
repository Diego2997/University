using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAPIBackend.DataAccess;
using UniversityAPIBackend.Interface;
using UniversityAPIBackend.Models.DataModels;

namespace UniversityAPIBackend.Controllers
{
    [Route("api/[controller]")]//https://localhost:7147/api/users
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly IUserService _userService;

        public UsersController(UniversityDBContext context,IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: https://localhost:7147/api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return users.ToList();
        }
        

        // GET: api/Users/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetOneUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("GetUserByEmail")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            try
            {
            var user = await _userService.FindUserByEmail(email);

            if (user == null)
            {
            }
            return Ok(user);

            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }


        }

        // PUT: https://localhost:7147/api/user/1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }
            
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: https://localhost:7147/api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }

        // DELETE: https://localhost:7147/api/users/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
