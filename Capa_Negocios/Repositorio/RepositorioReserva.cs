using BETripWay.CapaNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Vuelos.Repositorios
{
    public class RepositorioReserva : IRepositorioReserva
    {
        private readonly AppDbContext context;

        public RepositorioReserva(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Reserva>> ObtenerTodos()
        {
            return await context.Reservas.ToListAsync();
        }

        public async Task<Reserva?> ObtenerPorId(int id)
        {
            return await context.Reservas.FindAsync(id);
        }

        public async Task<int> CrearReserva(Reserva reserva)
        {
            context.Reservas.Add(reserva);
            return await context.SaveChangesAsync();
        }

        public async Task<int> ModificarReserva(Reserva reserva)
        {
            context.Reservas.Update(reserva);
            return await context.SaveChangesAsync();
        }

        public async Task EliminarReserva(int id)
        {
            var reserva = await context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                context.Reservas.Remove(reserva);
                await context.SaveChangesAsync();
            }
        }

    }
}
