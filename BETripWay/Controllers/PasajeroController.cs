using BETripWay.CapaNegocio;
using Gestion_Vuelos.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETripWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasajeroController : ControllerBase
    {

        private readonly IRepositorioPasajero _repositorioPasajero;

        public PasajeroController(IRepositorioPasajero repositorioPasajero)
        {
            _repositorioPasajero = repositorioPasajero;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pasajero>>> Get()
        {
            return await _repositorioPasajero.ObtenerTodos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pasajero?>> Get(int id)
        {
            var pasajero = await _repositorioPasajero.ObtenerPorId(id);
            if (pasajero == null)
            {
                return NotFound();
            }
            return pasajero;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Pasajero pasajero)
        {
            await _repositorioPasajero.Crear(pasajero);
            return CreatedAtAction(nameof(Get), new { id = pasajero.Id }, pasajero);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Pasajero pasajero)
        {
            if (id != pasajero.Id)
            {
                return BadRequest();
            }

            await _repositorioPasajero.ModificarPasajero(pasajero);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pasajero = await _repositorioPasajero.ObtenerPorId(id);
            if (pasajero == null)
            {
                return NotFound();
            }

            await _repositorioPasajero.EliminarPasajero(id);
            return NoContent();
        }


    }
}
