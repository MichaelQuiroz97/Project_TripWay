using BETripWay.CapaNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public class RepositorioHotel: IRepositorioHotel
    {
        private readonly AppDbContext _context;
        public RepositorioHotel(AppDbContext context)
        {
            _context = context;   
        }

        public async Task<List<Hotel>> GetListHoteles()
        {
            List<Hotel> listHoteles = await _context.Hotels.ToListAsync();
            return listHoteles;
        }

        public async Task<Hotel> GetHotel(int IdHotel)
        {
            Hotel hotel = await _context.Hotels.FindAsync(IdHotel);
            return hotel;
        }

        public async Task DeleteHotel(Hotel hotel)
        {
            try
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex) { 
            }
        }

        public async Task<Hotel> AddHotel(Hotel hotel)
        {
            try
            {

                _context.Add(hotel);
                await _context.SaveChangesAsync();
                return hotel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task UpdateHotel(Hotel hotel)
        {
            var hotelItem = await _context.Hotels.FirstOrDefaultAsync(x => x.IdHotel == hotel.IdHotel);

            if (hotelItem != null)
            {
                hotelItem.IdCiudad = hotel.IdCiudad;
                hotelItem.Direccion = hotel.Direccion;
                hotelItem.Nhabitaciones = hotel.Nhabitaciones;
                hotelItem.Estado = hotel.Estado;

                await _context.SaveChangesAsync();
            }
        }
    }
}
