

namespace ProductApplication.Models 
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> AddUser(Users newUser);
        Task<Users> GetById(int id);
        Task<Users> UodateUser(int id, Users updatedUser);
        Task DeleteUser(int id);
    }
}