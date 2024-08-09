using BETripWay.CapaNegocio;
using CapaServicio.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETripWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {

        private readonly IRepositorioComentario _repositorioComentario;

        public ComentarioController(IRepositorioComentario repositorioComentario)
        {
            _repositorioComentario = repositorioComentario;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var comentario = await _repositorioComentario.ObtenerPorId(id);
                if (comentario == null)
                {
                    return NotFound();
                }

                return Ok(comentario);
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
                var comentario = await _repositorioComentario.ObtenerPorId(id);
                if (comentario == null)
                {
                    return NotFound();
                }

                await _repositorioComentario.EliminarComentario(comentario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Comentario comentario)
        {
            try
            {
                await _repositorioComentario.Crear(comentario);
                return CreatedAtAction("Get", new { id = comentario.Id }, comentario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Comentario comentario)
        {
            try
            {
                if (id != comentario.Id)
                {
                    return BadRequest();
                }

                var comentarioItem = await _repositorioComentario.ObtenerPorId(id);

                if (comentarioItem == null)
                {
                    return NotFound();
                }

                await _repositorioComentario.ModificarComentario(comentario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
