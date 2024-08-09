using BETripWay.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public interface IRepositorioUsuario
    {

        Task<List<Usuario>> GetListUsuario();
        Task<Usuario> GetUsuario(string cedula);
        Task<Usuario> AddUsuario(Usuario usuario);
        Task<Usuario> GetUsuarioByCorreo(string correo, string contrasenia);


    }
}
