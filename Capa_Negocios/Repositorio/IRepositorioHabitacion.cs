using BETripWay.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public interface IRepositorioHabitacion
    {
        Task<List<Habitacion>> GetListHabitaciones();
        Task<Habitacion> GetHabitacion(int IdHabitacion);
        Task DeleteHabitacion(Habitacion habitacion);
        Task<Habitacion> AddHabitacion(Habitacion habitacion);
        Task UpdateHabitacion(Habitacion habitacion);
    }
}
