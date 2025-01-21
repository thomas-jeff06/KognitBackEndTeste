using KognitBackEndTeste.Models;

namespace KognitBackEndTeste.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User?> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task DeleteUserAsync(User user);
    }
}
