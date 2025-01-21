using KognitBackEndTeste.Models;

namespace KognitBackEndTeste.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<User?> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<bool> DeleteUserAsync(int userId);

    }
}
