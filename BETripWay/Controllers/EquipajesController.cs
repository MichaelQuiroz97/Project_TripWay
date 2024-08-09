using BETripWay.CapaNegocio;
using CapaServicio.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETripWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipajesController : ControllerBase
    {

        private readonly IRepositorioEquipaje _repositorioEquipaje;

        public EquipajesController(IRepositorioEquipaje repositorioEquipaje)
        {
            _repositorioEquipaje = repositorioEquipaje;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listEquipajes = await _repositorioEquipaje.GetListEquipaje();
                return Ok(listEquipajes);
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
                var equipaje = await _repositorioEquipaje.GetEquipaje(id);
                if (equipaje == null)
                {
                    return NotFound();
                }

                return Ok(equipaje);
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
                var equipaje = await _repositorioEquipaje.GetEquipaje(id);
                if (equipaje == null)
                {
                    return NotFound();
                }

                await _repositorioEquipaje.DeleteEquipaje(equipaje);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Equipaje equipaje)
        {
            try
            {
                await _repositorioEquipaje.AddEquipaje(equipaje);
                return CreatedAtAction("Get", new { id = equipaje.Id }, equipaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Equipaje equipaje)
        {
            try
            {
                if (id != equipaje.Id)
                {
                    return BadRequest();
                }

                var equipajeItem = await _repositorioEquipaje.GetEquipaje(id);

                if (equipajeItem == null)
                {
                    return NotFound();
                }

                await _repositorioEquipaje.UpdateEquipaje(equipaje);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
