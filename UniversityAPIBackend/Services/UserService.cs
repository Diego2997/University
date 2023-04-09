using Microsoft.EntityFrameworkCore;
using UniversityAPIBackend.DataAccess;
using UniversityAPIBackend.Interface;
using UniversityAPIBackend.Models.DataModels;

namespace UniversityAPIBackend.Services
{
    public class UserService : IUserService
    {
        private readonly UniversityDBContext _context;
        public UserService(UniversityDBContext context) 
        {
            _context = context;
        }
        public async Task<User> FindUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetOneUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public Task<bool> UpdateUser(int id, User user)
        {

            return true;
        }
    }
}
