using BETripWay.CapaNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio.Repositorio
{
    public class RepositorioEquipaje : IRepositorioEquipaje
    {

        private readonly AppDbContext _context;

        public RepositorioEquipaje(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Equipaje> AddEquipaje(Equipaje equipaje)
        {
            _context.Add(equipaje);
            await _context.SaveChangesAsync();
            return equipaje;
        }

        public async Task DeleteEquipaje(Equipaje equipaje)
        {
            _context.Equipajes.Remove(equipaje);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Equipaje>> GetListEquipaje()
        {
            return await _context.Equipajes.ToListAsync();
        }

        public async Task<Equipaje> GetEquipaje(int id)
        {
            return await _context.Equipajes.FindAsync(id);
        }

        public async Task UpdateEquipaje(Equipaje equipaje)
        {
            var equipajeItem = await _context.Equipajes.FirstOrDefaultAsync(x => x.Id == equipaje.Id);

            if (equipajeItem != null)
            {
                equipajeItem.CedulaUsuario = equipaje.CedulaUsuario;
                equipajeItem.Peso = equipaje.Peso;
                equipajeItem.Tipo = equipaje.Tipo;
                equipajeItem.Estado = equipaje.Estado;

                await _context.SaveChangesAsync();
            }
        }

    }
}
