using KognitBackEndTeste.Models;
using KognitBackEndTeste.Repositories;

namespace KognitBackEndTeste.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IUserRepository _userRepository;

        public WalletService(IWalletRepository walletRepository, IUserRepository userRepository)
        {
            _walletRepository = walletRepository;
            _userRepository = userRepository;
        }

        public async Task<Wallet> CreateWalletAsync(Wallet wallet)
        {
            var userExists = await _userRepository.GetUserByIdAsync(wallet.UserId);
            if (userExists == null)
            {
                throw new ArgumentException($"Usuário com ID {wallet.UserId} não encontrado.");
            }
            if (wallet.CurrentValue < 0)
            {
                throw new ArgumentException("O valor inicial da carteira deve ser positivo.");
            }

            return await _walletRepository.AddWalletAsync(wallet);
        }

        public async Task<IEnumerable<Wallet>> GetWalletsByUserIdAsync(int userId)
        {
            return await _walletRepository.GetWalletsByUserIdAsync(userId);
        }

        public async Task<Wallet?> GetWalletByIdAsync(int id)
        {
            return await _walletRepository.GetWalletByIdAsync(id);
        }

        public async Task<bool> DeleteWalletAsync(int walletId)
        {
            var wallet = await _walletRepository.GetWalletByIdAsync(walletId);
            if (wallet == null)
            {
                throw new ArgumentException("Carteira não encontrada.");
            }

            await _walletRepository.DeleteWalletAsync(wallet);
            return true;
        }
    }
}
