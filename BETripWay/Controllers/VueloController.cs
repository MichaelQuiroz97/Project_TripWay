using BETripWay.CapaNegocio;
using CapaServicio.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETripWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {

        private readonly IRepositorioVuelo _repositorioVuelos;


        public VueloController(IRepositorioVuelo repositorioVuelo)
        {
            _repositorioVuelos = repositorioVuelo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var ListVuelos = await _repositorioVuelos.ObtenerTodos();
                return Ok(ListVuelos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Vuelo vuelo)
        {
            try
            {
                var id = await _repositorioVuelos.Crear(vuelo);
                return Ok(id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repositorioVuelos.EliminarVuelo(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Vuelo vuelo)
        {
            try
            {
                await _repositorioVuelos.EditarVuelo(vuelo);
                return Ok(vuelo.Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

    }
}
