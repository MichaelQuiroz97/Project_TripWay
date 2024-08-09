using BETripWay.CapaNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public class RepositorioComentario :IRepositorioComentario
    {

        private readonly AppDbContext _context;

        public RepositorioComentario(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comentario> Crear(Comentario comentario)
        {
            _context.Add(comentario);
            await _context.SaveChangesAsync();
            return comentario;
        }
        public async Task<List<Comentario>> GetListComentario()
        {
            return await _context.Comentarios.ToListAsync();
        }


        public async Task<Comentario?> ObtenerPorId(int id)
        {
            return await _context.Comentarios.FindAsync(id);
        }

        public async Task ModificarComentario(Comentario comentario)
        {
            // Buscar el comentario en la base de datos por su ID
            var comentarioItem = await _context.Comentarios.FirstOrDefaultAsync(x => x.Id == comentario.Id);

            if (comentarioItem != null)
            {
                // Actualizar las propiedades del comentario
                comentarioItem.ComentarioTexto = comentario.ComentarioTexto;
                comentarioItem.CedulaUsuario = comentario.CedulaUsuario;
                comentarioItem.CedulaUsuarioNavigation = comentario.CedulaUsuarioNavigation;

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarComentario(Comentario comentario)
        {
            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
        }



    }
}
