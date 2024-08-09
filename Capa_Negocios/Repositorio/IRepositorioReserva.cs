using BETripWay.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Vuelos.Repositorios
{
    public interface IRepositorioReserva
    {
        Task<List<Reserva>> ObtenerTodos();
        Task<Reserva?> ObtenerPorId(int id);
        Task<int> CrearReserva(Reserva reserva);

        Task EliminarReserva(int id);
        Task<int> ModificarReserva(Reserva reserva);
    }
}
