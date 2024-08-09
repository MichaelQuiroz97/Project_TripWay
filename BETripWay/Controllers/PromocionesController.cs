using BETripWay.CapaNegocio;
using CapaServicio.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace BETripWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionesController : ControllerBase
    {

        private readonly IRepositorioPromocion _repositorioPromocion;
        public PromocionesController(IRepositorioPromocion repositorioPromocion)
        {
            _repositorioPromocion = repositorioPromocion;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListPromociones = await _repositorioPromocion.GetListPromocion();
                return Ok(ListPromociones);
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
                var promocion = await _repositorioPromocion.GetPromocion(id);
                if (promocion == null)
                {
                    return NotFound();
                }

                return Ok(promocion);
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
                var promocion = await _repositorioPromocion.GetPromocion(id);
                if (promocion == null)
                {
                    return NotFound();
                }
                await _repositorioPromocion.DeletePromocion(promocion);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Promocion promocion)
        {
            try
            {
                 await _repositorioPromocion.AddPromocion(promocion);

              
                return CreatedAtAction("Get", new { id = promocion.Id }, promocion);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Promocion promocion)
        {
            try
            {
               
                if (id != promocion.Id)
                {
                    return BadRequest();
                }

                var promocionItem = await _repositorioPromocion.GetPromocion(id);

                if (promocionItem == null)
                {
                    return NotFound();
                }


                await _repositorioPromocion.UpdatePromocion(promocion);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
