using ComercialClienteAPI.Models;
using ComercialClienteAPI.Service;
using Microsoft.AspNetCore.Mvc;
using ComercialClienteAPI.Models.Dto;


namespace ComercialClienteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pserv;

        public PedidoController(PedidoService pserv)
        {
            _pserv = pserv;
        }

        // GET: api/pedido/uno/5
        [HttpGet("uno/{idPedido}")]
        public ActionResult<PedidoDto> GetUno(int idPedido)
        {
            var pedido = _pserv.BuscarUno(idPedido);
            if (pedido == null) return NotFound("Pedido no encontrado");

            var dto = new PedidoDto
            {
                IdPedido = pedido.IdPedido,
                Importe = pedido.Importe,
                Fecha = pedido.Fecha,
                IdCliente = pedido.Cliente.IdCliente,
                IdComercial = pedido.Comercial.IdComercial
            };

            return Ok(dto);
        }

        // GET: api/pedido/comercial/3
        [HttpGet("comercial/{idComercial}")]
        public ActionResult<IEnumerable<PedidoDto>> GetPedidosPorComercial(int idComercial)
        {
            var pedidos = _pserv.PedidosPorComercial(idComercial);

            if (!pedidos.Any()) return NotFound();

            var dtos = pedidos.Select(p => new PedidoDto
            {
                IdPedido = p.IdPedido,
                Importe = p.Importe,
                Fecha = p.Fecha,
                IdCliente = p.Cliente.IdCliente,
                IdComercial = p.Comercial.IdComercial
            });

            return Ok(dtos);
        }

        // GET: api/pedido/totalpedidos
        [HttpGet("totalpedidos")]
        public ActionResult<Dictionary<string, double>> GetTotalPorComercial()
        {
            var resultado = _pserv.TotalPedidosPorComercial();
            if (resultado.Count == 0) return NotFound();

            return Ok(resultado);
        }
    }
}
