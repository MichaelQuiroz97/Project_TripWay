using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
   public class Habitacion
    {
        public int IdHabitaciones { get; set; }
        public int IdHotel { get; set; }
        public int Capacidad { get; set; }
        public string TipoHabitacion { get; set; }
        public string descripcion { get; set; }
        public string CedulaUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public bool estado { get; set; }
    }
}
