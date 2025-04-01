using ComercialClienteAPI.Models;

namespace ComercialClienteAPI.Service
{
    public interface PedidoService
    {
        Pedido? BuscarUno(int idPedido);
        IEnumerable<Pedido> PedidosPorCliente(int idCliente);
        IEnumerable<Pedido> PedidosPorComercial(int idComercial);
        Dictionary<string, double> TotalPedidosPorComercial();
    }
}
