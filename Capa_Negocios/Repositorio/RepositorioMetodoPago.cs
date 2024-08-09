using BETripWay.CapaNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Vuelos.Repositorios
{
    public class RepositorioMetodoPago: IRepositorioMetodoPago
    {
        private readonly AppDbContext context;

        public RepositorioMetodoPago(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<MetodoPago>> ObtenerTodos()
        {
            return await context.MetodoPagos.ToListAsync();
        }

        public async Task<MetodoPago?> ObtenerId(int id)
        {
            return await context.MetodoPagos.FindAsync(id);
        }

        public async Task<int> CrearPago(MetodoPago metodoPago)
        {
            context.MetodoPagos.Add(metodoPago);
            return await context.SaveChangesAsync();
        }

        public async Task<MetodoPago> ModificarPago(MetodoPago metodoPago)
        {
            context.MetodoPagos.Update(metodoPago);
            await context.SaveChangesAsync();
            return metodoPago;
        }

        public async Task EliminarPago(int id)
        {
            var metodoPago = await context.MetodoPagos.FindAsync(id);
            if (metodoPago != null)
            {
                context.MetodoPagos.Remove(metodoPago);
                await context.SaveChangesAsync();
            }
        }
    }
}
