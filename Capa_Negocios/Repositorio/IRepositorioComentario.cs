using BETripWay.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public interface IRepositorioComentario
    {

        Task<List<Comentario>> GetListComentario();
        Task<Comentario> ObtenerPorId(int id);
        Task<Comentario> Crear(Comentario comentario);

        Task EliminarComentario(Comentario comentario);
        Task ModificarComentario(Comentario comentario);

    }
}
