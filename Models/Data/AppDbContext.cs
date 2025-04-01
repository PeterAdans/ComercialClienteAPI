using Microsoft.EntityFrameworkCore;
using ComercialClienteAPI.Models;

namespace ComercialClienteAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Comercial> Comerciales { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
