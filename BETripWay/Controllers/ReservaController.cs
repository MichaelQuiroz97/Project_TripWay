using BETripWay.CapaNegocio;
using Gestion_Vuelos.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETripWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {

        private readonly IRepositorioReserva _repositorioReserva;

        public ReservaController(IRepositorioReserva repositorioReserva)
        {
            _repositorioReserva = repositorioReserva;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reserva>>> Get()
        {
            return await _repositorioReserva.ObtenerTodos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva?>> Get(int id)
        {
            var reserva = await _repositorioReserva.ObtenerPorId(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return reserva;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Reserva reserva)
        {
            await _repositorioReserva.CrearReserva(reserva);
            return CreatedAtAction(nameof(Get), new { id = reserva.Id }, reserva);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return BadRequest();
            }

            await _repositorioReserva.ModificarReserva(reserva);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var reserva = await _repositorioReserva.ObtenerPorId(id);
            if (reserva == null)
            {
                return NotFound();
            }

            await _repositorioReserva.EliminarReserva(id);
            return NoContent();
        }

    }
}
