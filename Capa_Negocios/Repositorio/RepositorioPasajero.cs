using BETripWay.CapaNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Vuelos.Repositorios
{
    public class RepositorioPasajero: IRepositorioPasajero
    {
        private readonly AppDbContext context;

        public RepositorioPasajero(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Pasajero>> ObtenerTodos()
        {
            return await context.Pasajeros.ToListAsync();
        }

        public async Task<Pasajero?> ObtenerPorId(int id)
        {
            return await context.Pasajeros.FindAsync(id);
        }

        public async Task<int> Crear(Pasajero pasajero)
        {
            context.Pasajeros.Add(pasajero);
            return await context.SaveChangesAsync();
        }

        public async Task<Pasajero> ModificarPasajero(Pasajero pasajero)
        {
            context.Pasajeros.Update(pasajero);
            await context.SaveChangesAsync();
            return pasajero;
        }

        public async Task EliminarPasajero(int id)
        {
            var pasajero = await context.Pasajeros.FindAsync(id);
            if (pasajero != null)
            {
                context.Pasajeros.Remove(pasajero);
                await context.SaveChangesAsync();
            }
        }
    }
}
