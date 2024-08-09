using BETripWay.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public interface IRepositorioAeropuerto
    {

        Task<List<Aeropuerto>> ObtenerTodos();
        Task<int> Crear(Aeropuerto aeropuerto);
        Task<Aeropuerto> EditarAeropuerto(Aeropuerto aeropuerto);
        Task EliminarAeropuerto(int id);

    }
}
