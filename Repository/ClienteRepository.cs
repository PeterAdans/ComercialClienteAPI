using ComercialClienteAPI.Models;
using ComercialClienteAPI.Data;

namespace ComercialClienteAPI.Repository
{
    public class ClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente? GetById(int id)
        {
            return _context.Clientes.Find(id);
        }

        public Cliente Save(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public void Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _context.Clientes.Any(c => c.IdCliente == id);
        }
    }
}
