using BETripWay.CapaNegocio;
using CapaServicio.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETripWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IRepositorioUsuario _repositorioUsuario;

        public UsuariosController(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listUsuarios = await _repositorioUsuario.GetListUsuario();
                return Ok(listUsuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{cedula}")]
        public async Task<IActionResult> Get(string cedula)
        {
            try
            {
                var usuario = await _repositorioUsuario.GetUsuario(cedula);
                if (usuario == null)
                {
                    return NotFound();
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            try
            {
                await _repositorioUsuario.AddUsuario(usuario);
                return CreatedAtAction("Get", new { id = usuario.CedulaUsuario }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("byCorreo/{correo}/{contrasenia}")]
        public async Task<IActionResult> GetUsuarioByCorreo(string correo, string contrasenia)
        {
            try
            {
                var usuario = await _repositorioUsuario.GetUsuarioByCorreo(correo, contrasenia);
                if (usuario != null)
                {
                    return Ok(new { cedula = usuario.CedulaUsuario });
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
