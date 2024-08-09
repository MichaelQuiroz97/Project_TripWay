using BETripWay.CapaNegocio;
using Gestion_Vuelos.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETripWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagoController : ControllerBase
    {

        private readonly IRepositorioMetodoPago _repositorioPago;

        public MetodoPagoController(IRepositorioMetodoPago repositorioMetodoPago)
        {
            _repositorioPago = repositorioMetodoPago;
        }

        [HttpGet]
        public async Task<ActionResult<List<MetodoPago>>> Get()
        {
            return await _repositorioPago.ObtenerTodos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MetodoPago?>> Get(int id)
        {
            var metodoPago = await _repositorioPago.ObtenerId(id);
            if (metodoPago == null)
            {
                return NotFound();
            }
            return metodoPago;
        }

        [HttpPost]
        public async Task<ActionResult> Post(MetodoPago metodoPago)
        {
            await _repositorioPago.CrearPago(metodoPago);
            return CreatedAtAction(nameof(Get), new { id = metodoPago.Id }, metodoPago);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, MetodoPago metodoPago)
        {
            if (id != metodoPago.Id)
            {
                return BadRequest();
            }

            await _repositorioPago.ModificarPago(metodoPago);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var metodoPago = await _repositorioPago.ObtenerId(id);
            if (metodoPago == null)
            {
                return NotFound();
            }

            await _repositorioPago.EliminarPago(id);
            return NoContent();
        }

    }
}
