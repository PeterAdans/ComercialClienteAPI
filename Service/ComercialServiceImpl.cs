using ComercialClienteAPI.Models;
using ComercialClienteAPI.Repository;

namespace ComercialClienteAPI.Service
{
    public class ComercialServiceImpl : ComercialService
    {
        private readonly ComercialRepository _crepo;
        private readonly PedidoRepository _prepo;

        public ComercialServiceImpl(ComercialRepository crepo, PedidoRepository prepo)
        {
            _crepo = crepo;
            _prepo = prepo;
        }

        public Comercial AltaComercial(Comercial comercial)
        {
            if (_crepo.Exists(comercial.IdComercial))
                return null!;

            return _crepo.Save(comercial);
        }

        public int EliminarComercial(int idComercial)
        {
            if (!_crepo.Exists(idComercial))
                return 0;

            _crepo.Delete(idComercial);
            return 1;
        }

        public Comercial? BuscarUno(int idComercial)
        {
            return _crepo.GetById(idComercial);
        }

        public IEnumerable<Comercial> FindAll()
        {
            return _crepo.GetAll();
        }

        public IEnumerable<Comercial> ByCliente(int idCliente)
        {
            var pedidos = _prepo.GetAll();
            return pedidos
                .Where(p => p.Cliente.IdCliente == idCliente)
                .Select(p => p.Comercial)
                .Distinct()
                .ToList();
        }

        public IEnumerable<Comercial> SinPedidos()
        {
            var todos = _crepo.GetAll();
            var pedidos = _prepo.GetAll();

            return todos
                .Where(c => !pedidos.Any(p => p.Comercial.IdComercial == c.IdComercial))
                .ToList();
        }
    }
}
