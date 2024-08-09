using BETripWay.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public interface IRepositorioHotel
    {

        Task<List<Hotel>> GetListHoteles();
        Task<Hotel> GetHotel(int IdHotel);
        Task DeleteHotel(Hotel hotel);
        Task<Hotel> AddHotel(Hotel hotel);
        Task UpdateHotel(Hotel hotel);

    }
}
