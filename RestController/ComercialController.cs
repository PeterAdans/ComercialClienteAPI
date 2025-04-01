using ComercialClienteAPI.Models;
using ComercialClienteAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace ComercialClienteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComercialController : ControllerBase
    {
        private readonly ComercialService _comercialService;
        private readonly PedidoService _pedidoService;

        public ComercialController(ComercialService comercialService, PedidoService pedidoService)
        {
            _comercialService = comercialService;
            _pedidoService = pedidoService;
        }

        // POST: api/comercial/alta
        [HttpPost("alta")]
        public ActionResult<Comercial> Alta([FromBody] Comercial comercial)
        {
            var creado = _comercialService.AltaComercial(comercial);
            return CreatedAtAction(nameof(Uno), new { idComercial = creado.IdComercial }, creado);
        }

        // DELETE: api/comercial/eliminar/5
        [HttpDelete("eliminar/{idComercial}")]
        public ActionResult<string> Eliminar(int idComercial)
        {
            var resultado = _comercialService.EliminarComercial(idComercial);
            return resultado switch
            {
                1 => Ok("Comercial eliminado correctamente"),
                0 => NotFound("Comercial no existe"),
                -1 => Conflict("Problema en la base de datos. Llame a servicio técnico"),
                _ => StatusCode(500, "Error inesperado")
            };
        }

        // GET: api/comercial/uno/5
        [HttpGet("uno/{idComercial}")]
        public ActionResult<Comercial> Uno(int idComercial)
        {
            var comercial = _comercialService.BuscarUno(idComercial);
            return comercial != null ? Ok(comercial) : NotFound("Producto no existe");
        }

        // GET: api/comercial/bycliente/3
        [HttpGet("bycliente/{idCliente}")]
        public ActionResult<IEnumerable<Comercial>> ByCliente(int idCliente)
        {
            var comerciales = _comercialService.ByCliente(idCliente);
            if (!comerciales.Any()) return NotFound();
            return Ok(comerciales);
        }

        // GET: api/comercial/sinpedidos
        [HttpGet("sinpedidos")]
        public ActionResult<IEnumerable<Comercial>> SinPedidos()
        {
            var comerciales = _comercialService.SinPedidos();
            if (!comerciales.Any()) return NotFound();
            return Ok(comerciales);
        }
    }
}
