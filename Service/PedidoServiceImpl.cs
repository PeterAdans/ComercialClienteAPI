using ComercialClienteAPI.Models;
using ComercialClienteAPI.Repository;

namespace ComercialClienteAPI.Service
{
    public class PedidoServiceImpl : PedidoService
    {
        private readonly PedidoRepository _prepo;

        public PedidoServiceImpl(PedidoRepository prepo)
        {
            _prepo = prepo;
        }

        public Pedido? BuscarUno(int idPedido)
        {
            return _prepo.FindById(idPedido);
        }

        public IEnumerable<Pedido> PedidosPorCliente(int idCliente)
        {
            return _prepo.GetAll()
                         .Where(p => p.Cliente.IdCliente == idCliente)
                         .ToList();
        }

        public IEnumerable<Pedido> PedidosPorComercial(int idComercial)
        {
            return _prepo.GetAll()
                         .Where(p => p.Comercial.IdComercial == idComercial)
                         .ToList();
        }

        public Dictionary<string, double> TotalPedidosPorComercial()
        {
            var pedidos = _prepo.GetAll();

            return pedidos
                .Where(p => p.Comercial != null)
                .GroupBy(p => 
                    $"{p.Comercial.Nombre} {p.Comercial.Apellido1}" + 
                    (p.Comercial.Apellido2 != null ? $" {p.Comercial.Apellido2}" : "")
                )
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(p => p.Importe)
                );
        }
    }
}
