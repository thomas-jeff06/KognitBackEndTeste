using KognitBackEndTeste.Models;
using KognitBackEndTeste.Repositories;

namespace KognitBackEndTeste.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;

        public UserService(IUserRepository userRepository, IWalletRepository walletRepository)
        {
            _userRepository = userRepository;
            _walletRepository = walletRepository;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            //Verifica se CPF contem numero de caractes certos e se contem apenas numeros
            if (!IsValid(user.SocialNumber))
            {
                throw new ArgumentException("CPF inválido.");
            }

            var existingUsers = await _userRepository.GetUsersAsync();
            if (existingUsers.Any(u => u.SocialNumber == user.SocialNumber))
            {
                throw new ArgumentException("Usuário já cadastrado.");
            }

            return await _userRepository.AddUserAsync(user);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            // Verifica se o usuário tem carteiras associadas
            var wallets = await _walletRepository.GetWalletsByUserIdAsync(userId);
            if (wallets.Any())
            {
                throw new InvalidOperationException("Não é possível excluir o usuário, pois ele tem carteiras associadas.");
            }

            // Exclui o usuário
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            await _userRepository.DeleteUserAsync(user);
            return true;
        }

        private static bool IsValid(string cpf)
        {
            // Remover caracteres não numéricos
            cpf = cpf.Replace(".", "").Replace("-", "");

            // Verificar se tem 11 dígitos
            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
                return false;

            // Implementação básica de validação de CPF
            var invalidCPFs = new List<string>
        {
            "00000000000", "11111111111", "22222222222", "33333333333", "44444444444",
            "55555555555", "66666666666", "77777777777", "88888888888", "99999999999"
        };

            if (invalidCPFs.Contains(cpf))
                return false;

            // Lógica de cálculo do CPF pode ser inserida aqui (baseado nos dígitos verificadores)
            // Para fins de simplicidade, estamos usando apenas a verificação de formato e CPF inválidos comuns

            return true;
        }
    }
}
