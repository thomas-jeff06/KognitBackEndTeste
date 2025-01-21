using KognitBackEndTeste.Models;

namespace KognitBackEndTeste.Repositories
{
    public interface IWalletRepository
    {
        Task<Wallet> AddWalletAsync(Wallet wallet);
        Task<IEnumerable<Wallet>> GetWalletsByUserIdAsync(int userId);
        Task<Wallet?> GetWalletByIdAsync(int id);
        Task DeleteWalletAsync(Wallet wallet);
    }
}
