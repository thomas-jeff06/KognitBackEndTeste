using KognitBackEndTeste.Models;

namespace KognitBackEndTeste.Services
{
    public interface IWalletService
    {
        Task<Wallet> CreateWalletAsync(Wallet wallet);
        Task<IEnumerable<Wallet>> GetWalletsByUserIdAsync(int userId);
        Task<Wallet?> GetWalletByIdAsync(int id);
        Task<bool> DeleteWalletAsync(int userId);
    }
}
