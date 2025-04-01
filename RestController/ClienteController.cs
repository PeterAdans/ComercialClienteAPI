using ComercialClienteAPI.Models;
using ComercialClienteAPI.Dto;
using ComercialClienteAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace ComercialClienteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/cliente/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> GetById(int id)
        {
            var cliente = _clienteService.BuscarUno(id);
            if (cliente == null) return NotFound("Cliente no encontrado");
            return Ok(cliente);
        }

        // GET: api/cliente
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetAll()
        {
            var clientes = _clienteService.FindAll();
            return Ok(clientes);
        }

        // POST: api/cliente/alta
        [HttpPost("alta")]
        public ActionResult<Cliente> Alta([FromBody] ClienteDto dto)
        {
            var nuevo = _clienteService.AltaCliente(dto.ToCliente());
            if (nuevo == null) return Conflict("Cliente ya existe");
            return CreatedAtAction(nameof(GetById), new { id = nuevo.IdCliente }, nuevo);
        }

        // DELETE: api/cliente/eliminar/5
        [HttpDelete("eliminar/{id}")]
        public ActionResult Eliminar(int id)
        {
            var resultado = _clienteService.EliminarCliente(id);
            return resultado switch
            {
                1 => Ok("Cliente eliminado correctamente"),
                0 => NotFound("Cliente no existe"),
                _ => StatusCode(500, "Error interno al eliminar el cliente")
            };
        }
    }
}
