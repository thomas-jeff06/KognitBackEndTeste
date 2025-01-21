using KognitBackEndTeste.Models;
using KognitBackEndTeste.Services;
using Microsoft.AspNetCore.Mvc;

namespace KognitBackEndTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWallet([FromBody] Wallet wallet)
        {
            try
            {
                var createdWallet = await _walletService.CreateWalletAsync(wallet);
                return Ok(new
                {
                    success = true,
                    message = "Carteira criada com sucesso!",
                    data = createdWallet
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("user/{userId:int}")]
        public async Task<IActionResult> GetWalletsByUserId(int userId)
        {
            var wallets = await _walletService.GetWalletsByUserIdAsync(userId);
            if (wallets == null || !wallets.Any())
                return NotFound();

            return Ok(wallets);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetWalletById(int id)
        {
            var wallet = await _walletService.GetWalletByIdAsync(id);

            if (wallet == null)
            {
                return NotFound(new { success = false, message = "Carteira não encontrada." });
            }

            return Ok(wallet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWallet(int id)
        {
            try
            {
                var result = await _walletService.DeleteWalletAsync(id);
                if (result)
                {
                    return NoContent(); // Retorna sucesso sem conteúdo
                }

                return BadRequest(new { success = false, message = "Erro ao excluir carteira." });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
    }
}
