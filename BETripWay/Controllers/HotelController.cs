using BETripWay.CapaNegocio;
using CapaServicio.Repositorio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BETripWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        IRepositorioHotel _repository;

        public HotelController(IRepositorioHotel repositpory)
        {
            _repository = repositpory;
        }

        // GET: api/<HotelController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var lisHoteles = await _repository.GetListHoteles();
                return Ok(lisHoteles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<HotelController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var hotel = await _repository.GetHotel(id);
                if (hotel == null)
                {
                    return NotFound();
                }

                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // POST api/<HotelController>
        [HttpPost]
        public async Task<IActionResult> Post(Hotel hotel)
        {

            try
            {
                await _repository.AddHotel(hotel);
                return Ok(hotel);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

        // PUT api/<HotelController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Hotel hotel)
        {
            try
            {

                if (id != hotel.IdHotel)
                {
                    return BadRequest();
                }

                var promocionItem = await _repository.GetHotel(id);

                if (promocionItem == null)
                {
                    return NotFound();
                }


                await _repository.UpdateHotel(hotel);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var hotel = await _repository.GetHotel(id);
                if (hotel == null)
                {
                    return NotFound();
                }
                await _repository.DeleteHotel(hotel);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
