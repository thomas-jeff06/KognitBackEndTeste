using Microsoft.EntityFrameworkCore;
using KognitBackEndTeste.Models;

namespace KognitBackEndTeste.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
