﻿using KognitBackEndTeste.Data;
using KognitBackEndTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace KognitBackEndTeste.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly AppDbContext _context;

        public WalletRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Wallet> AddWalletAsync(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            await _context.SaveChangesAsync();
            return wallet;
        }

        public async Task<IEnumerable<Wallet>> GetWalletsByUserIdAsync(int userId)
        {
            return await _context.Wallets
                .Where(w => w.UserId == userId)
                .ToListAsync();
        }

        public async Task<Wallet?> GetWalletByIdAsync(int id)
        {
            return await _context.Wallets.FindAsync(id);
        }

        public async Task DeleteWalletAsync(Wallet wallet)
        {
            _context.Wallets.Remove(wallet);
            await _context.SaveChangesAsync();
        }
    }
}
