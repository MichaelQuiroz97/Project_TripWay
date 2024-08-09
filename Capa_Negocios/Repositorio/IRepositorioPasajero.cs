
using BETripWay.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Vuelos.Repositorios
{
    public interface IRepositorioPasajero
    {
        Task<List<Pasajero>> ObtenerTodos();
        Task<Pasajero?> ObtenerPorId(int id);
        Task<int> Crear(Pasajero pasajero);

        Task<Pasajero> ModificarPasajero(Pasajero pasajero);

        Task EliminarPasajero(int id);
    }
}
