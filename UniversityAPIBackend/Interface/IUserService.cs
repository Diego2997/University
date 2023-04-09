using UniversityAPIBackend.Models.DataModels;

namespace UniversityAPIBackend.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetOneUser(int id);
        Task<User> FindUserByEmail(string email);
        Task<bool> UpdateUser(int id,User user);
    }
}
