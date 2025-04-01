using ComercialClienteAPI.Data;
using ComercialClienteAPI.Models;

namespace ComercialClienteAPI.Repository
{
    public class ComercialRepository
    {
        private readonly AppDbContext _context;

        public ComercialRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Comercial> GetAll() => _context.Comerciales.ToList();

        public Comercial? GetById(int id) => _context.Comerciales.Find(id);

        public Comercial Save(Comercial comercial)
        {
            _context.Comerciales.Add(comercial);
            _context.SaveChanges();
            return comercial;
        }

        public void Delete(int id)
        {
            var comercial = _context.Comerciales.Find(id);
            if (comercial != null)
            {
                _context.Comerciales.Remove(comercial);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id) => _context.Comerciales.Any(c => c.IdComercial == id);
    }
}
