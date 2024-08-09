using BETripWay.CapaNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public class RepositorioPromocion : IRepositorioPromocion
    {

        private readonly AppDbContext _context;

        public RepositorioPromocion(AppDbContext context)
        {
            _context = context;

        }

        public async Task<Promocion> AddPromocion(Promocion promocion)
        {

            try
            {
                _context.Add(promocion);
                await _context.SaveChangesAsync();
                return promocion;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                throw;
            }


            
        }

        public async Task DeletePromocion(Promocion promocion)
        {
            _context.Promocions.Remove(promocion);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Promocion>> GetListPromocion()
        {
            return await _context.Promocions.ToListAsync();
        }

        public async Task<Promocion> GetPromocion(int id)
        {
            return await _context.Promocions.FindAsync(id);
        }

        public async Task UpdatePromocion(Promocion promocion)
        {
            var promoItem = await _context.Promocions.FirstOrDefaultAsync(x => x.Id == promocion.Id);

            if (promoItem != null)
            {
                promoItem.Titulo = promocion.Titulo;
                promoItem.Descripcion = promocion.Descripcion;
                promoItem.Precio = promocion.Precio;
                promoItem.Destino = promocion.Destino;

                await _context.SaveChangesAsync();
            }
        }




    }
}
