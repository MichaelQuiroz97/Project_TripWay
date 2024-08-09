using BETripWay.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public  interface IRepositorioPromocion
    {

        Task<List<Promocion>> GetListPromocion();
        Task<Promocion> GetPromocion(int id);

        Task DeletePromocion(Promocion promocion);
        Task<Promocion> AddPromocion(Promocion promocion);
        Task UpdatePromocion(Promocion promocion);

    }
}
