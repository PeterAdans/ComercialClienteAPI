using ComercialClienteAPI.Models;
using ComercialClienteAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ComercialClienteAPI.Repository
{
    public class PedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pedido> GetAll()
        {
            return _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Comercial)
                .ToList();
        }

        public Pedido? FindById(int id)
        {
            return _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Comercial)
                .FirstOrDefault(p => p.IdPedido == id);
        }
    }
}
