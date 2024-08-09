using BETripWay.CapaNegocio;
using CapaServicio.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETripWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {

        IRepositorioHabitacion _repository;

        public HabitacionController(IRepositorioHabitacion repositpory)
        {
            _repository = repositpory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var lisHabitaciones = await _repository.GetListHabitaciones();
                return Ok(lisHabitaciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var habitacion = await _repository.GetHabitacion(id);
                if (habitacion == null)
                {
                    return NotFound();
                }

                return Ok(habitacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Habitacion habitacion)
        {

            try
            {
                await _repository.AddHabitacion(habitacion);
                return Ok(habitacion);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Habitacion habitacion)
        {
            try
            {

                if (id != habitacion.IdHotel)
                {
                    return BadRequest();
                }

                var habitacionItem = await _repository.GetHabitacion(id);

                if (habitacionItem == null)
                {
                    return NotFound();
                }


                await _repository.UpdateHabitacion(habitacion);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

  
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var habitacion = await _repository.GetHabitacion(id);
                if (habitacion == null)
                {
                    return NotFound();
                }
                await _repository.DeleteHabitacion(habitacion);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
