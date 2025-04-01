using ComercialClienteAPI.Models;

namespace ComercialClienteAPI.Service
{
    public interface ComercialService
    {
        Comercial AltaComercial(Comercial comercial);
        int EliminarComercial(int idComercial);
        Comercial? BuscarUno(int idComercial);
        IEnumerable<Comercial> FindAll();
        IEnumerable<Comercial> ByCliente(int idCliente);
        IEnumerable<Comercial> SinPedidos();
    }
}
