using BETripWay.CapaNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public class RepositorioUsuario: IRepositorioUsuario
    {

        private readonly AppDbContext _context;

        public RepositorioUsuario(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetListUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }


        public async Task<Usuario> GetUsuarioByCorreo(string correo, string contrasenia)
        {
            return await _context.Usuarios
               .Where(u => u.CorreoElectronico == correo && u.Contrasenia == contrasenia)
               .FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUsuario(string cedula)
        {
            return await _context.Usuarios
       .Where(u => u.CedulaUsuario == cedula)
       .FirstOrDefaultAsync();
        }
    }
}
