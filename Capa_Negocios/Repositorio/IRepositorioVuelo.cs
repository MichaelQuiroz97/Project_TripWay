using BETripWay.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public interface IRepositorioVuelo
    {

        Task<List<Vuelo>> ObtenerTodos();
        Task<int> Crear(Vuelo vuelo);
        Task<Vuelo> EditarVuelo(Vuelo vuelo);
        Task EliminarVuelo(int id);

    }
}
