using BETripWay.CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BETripWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeropuertoController : ControllerBase
    {


        private readonly AppDbContext _context;

        public AeropuertoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Aeropuertos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeropuerto>>> GetAeropuertos()
        {
            var aeropuertos = await _context.Aeropuertos.ToListAsync();

            return Ok(aeropuertos);
        }

        // GET: api/Aeropuertos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aeropuerto>> GetAeropuerto(int id)
        {
            var aeropuerto = await _context.Aeropuertos.FirstOrDefaultAsync(a => a.Id == id);

            if (aeropuerto == null)
            {
                return NotFound();
            }

            return Ok(aeropuerto);
        }

        // PUT: api/Aeropuertos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeropuerto(int id, Aeropuerto aeropuerto)
        {
            if (id != aeropuerto.Id)
            {
                return BadRequest();
            }

            _context.Entry(aeropuerto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeropuertoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Aeropuertos
        [HttpPost]
        public async Task<ActionResult<Aeropuerto>> PostAeropuerto(Aeropuerto aeropuerto)
        {
            _context.Aeropuertos.Add(aeropuerto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAeropuerto), new { id = aeropuerto.Id }, aeropuerto);
        }

        // DELETE: api/Aeropuertos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeropuerto(int id)
        {
            var aeropuerto = await _context.Aeropuertos.FindAsync(id);
            if (aeropuerto == null)
            {
                return NotFound();
            }

            _context.Aeropuertos.Remove(aeropuerto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeropuertoExists(int id)
        {
            return _context.Aeropuertos.Any(e => e.Id == id);
        }

    }
}
