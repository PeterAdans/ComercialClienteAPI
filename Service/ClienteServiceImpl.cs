using ComercialClienteAPI.Models;
using ComercialClienteAPI.Repository;

namespace ComercialClienteAPI.Service
{
    public class ClienteServiceImpl : ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteServiceImpl(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> FindAll()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente? BuscarUno(int idCliente)
        {
            return _clienteRepository.GetById(idCliente);
        }

        public Cliente AltaCliente(Cliente cliente)
        {
            if (_clienteRepository.Exists(cliente.IdCliente))
                return null!;

            return _clienteRepository.Save(cliente);
        }

        public int EliminarCliente(int idCliente)
        {
            if (!_clienteRepository.Exists(idCliente))
                return 0;

            _clienteRepository.Delete(idCliente);
            return 1;
        }
    }
}
