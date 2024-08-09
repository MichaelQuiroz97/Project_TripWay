using BETripWay.CapaNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public class RepositorioVuelo :IRepositorioVuelo
    {

        private readonly AppDbContext context;
        public RepositorioVuelo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Vuelo>> ObtenerTodos()
        {
            return await context.Vuelos.ToListAsync();
        }
        public async Task<int> Crear(Vuelo vuelo)
        {
            await context.Vuelos.AddAsync(vuelo);
            await context.SaveChangesAsync();
            return vuelo.Id;
        }

        public async Task<Vuelo> EditarVuelo(Vuelo vuelo)
        {
            Vuelo vueloEdit = await context.Vuelos.FindAsync(vuelo.Id);
            vueloEdit.Nvuelo = vuelo.Nvuelo;
            vueloEdit.Fpartida = vuelo.Fpartida;
            vueloEdit.Nocturno = vuelo.Nocturno;
            await context.SaveChangesAsync();
            return vueloEdit;
        }

        public async Task EliminarVuelo(int id)
        {
            Vuelo vuelo = await context.Vuelos.FindAsync(id);
            context.Vuelos.Remove(vuelo);
            await context.SaveChangesAsync();
        }

    }
}
