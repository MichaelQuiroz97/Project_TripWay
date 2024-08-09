using BETripWay.CapaNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public class RepositorioAeropuerto :IRepositorioAeropuerto
    {

        private readonly AppDbContext context;
        public RepositorioAeropuerto(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Aeropuerto>> ObtenerTodos()
        {
            return await context.Aeropuertos.ToListAsync();
        }
        public async Task<int> Crear(Aeropuerto aeropuerto)
        {
            context.Aeropuertos.Add(aeropuerto);
            await context.SaveChangesAsync();

            return aeropuerto.Id;
        }

        public async Task<Aeropuerto> EditarAeropuerto(Aeropuerto aeropuerto)
        {
            Aeropuerto aeroEdit = await context.Aeropuertos.FindAsync(aeropuerto);
            aeroEdit.Nombre = aeropuerto.Nombre;
            aeroEdit.Transporte = aeropuerto.Transporte;
            aeroEdit.Ciudad = aeropuerto.Ciudad;
            await context.SaveChangesAsync();
            return aeroEdit;
        }

        public async Task EliminarAeropuerto(int id)
        {
            Aeropuerto aeropuerto = await context.Aeropuertos.FindAsync(id);
            context.Aeropuertos.Remove(aeropuerto);
            await context.SaveChangesAsync();
        }

        
      
    }
}
