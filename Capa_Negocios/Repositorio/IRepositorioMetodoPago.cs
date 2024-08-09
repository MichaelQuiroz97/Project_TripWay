using BETripWay.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Vuelos.Repositorios
{
    public interface IRepositorioMetodoPago
    {
        Task<List<MetodoPago>> ObtenerTodos();
        Task<MetodoPago?> ObtenerId(int id);
        Task <int> CrearPago(MetodoPago metodoPago);
        Task<MetodoPago> ModificarPago(MetodoPago metodoPago);
        Task EliminarPago(int id);
    }
}
