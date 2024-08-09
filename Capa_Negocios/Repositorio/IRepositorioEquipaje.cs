using BETripWay.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public interface IRepositorioEquipaje
    {

        Task<List<Equipaje>> GetListEquipaje();
        Task<Equipaje> GetEquipaje(int id);
        Task DeleteEquipaje(Equipaje equipaje);
        Task<Equipaje> AddEquipaje(Equipaje equipaje);
        Task UpdateEquipaje(Equipaje equipaje);


    }
}
