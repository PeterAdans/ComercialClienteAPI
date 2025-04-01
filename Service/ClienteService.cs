using ComercialClienteAPI.Models;

namespace ComercialClienteAPI.Service
{
    public interface ClienteService
    {
        IEnumerable<Cliente> FindAll();
        Cliente? BuscarUno(int idCliente);
        Cliente AltaCliente(Cliente cliente);
        int EliminarCliente(int idCliente);
    }
}
