using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIda { get; set; }
        public DateTime FechaRegreso { get; set; }
        public string CiudadOrigen { get; set; }
        public string Destino { get; set; }
        public int Viaje { get; set; }
        public string Clase { get; set; }
        public List<Pasajero> Pasajeros { get; set; }
    }


}
