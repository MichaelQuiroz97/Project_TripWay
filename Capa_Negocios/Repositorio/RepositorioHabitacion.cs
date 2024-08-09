using BETripWay.CapaNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public class RepositorioHabitacion :IRepositorioHabitacion
    {

        private readonly AppDbContext _context;
        public RepositorioHabitacion(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Habitacion>> GetListHabitaciones()
        {
            List<Habitacion> listHabitaciones = await _context.Habitacions.ToListAsync();
            return listHabitaciones;
        }

        public async Task<Habitacion> GetHabitacion(int IdHabitacion)
        {
            Habitacion habitacion = await _context.Habitacions.FindAsync(IdHabitacion);
            return habitacion;
        }

        public async Task DeleteHabitacion(Habitacion habitacion)
        {
            try
            {
                _context.Habitacions.Remove(habitacion);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
            }
        }

        public async Task<Habitacion> AddHabitacion(Habitacion habitacion)
        {
            try
            {

                _context.Add(habitacion);
                await _context.SaveChangesAsync();
                return habitacion;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task UpdateHabitacion(Habitacion habitacion)
        {
            var habitacionItem = await _context.Habitacions.FirstOrDefaultAsync(x => x.IdHabitaciones == habitacion.IdHabitaciones);

            if (habitacionItem != null)
            {
                habitacionItem.IdHabitaciones = habitacion.IdHabitaciones;
                habitacionItem.IdHotel = habitacion.IdHotel;
                habitacionItem.Capacidad = habitacion.Capacidad;
                habitacionItem.TipoHabitacion = habitacion.TipoHabitacion;
                habitacionItem.Descripcion = habitacion.Descripcion;
                habitacionItem.CedulaUsuario = habitacion.CedulaUsuario;
                habitacionItem.Estado = habitacion.Estado;

                await _context.SaveChangesAsync();
            }
        }

    }
}
