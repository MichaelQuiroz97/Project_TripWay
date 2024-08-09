using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
   public class Hotel
    {
        public int IdHotel { get; set; }
        public int IdCiudad { get; set; }
        public string direccion { get; set; }
        public int Nhabitaciones { get; set; }
        public bool estado { get; set; }
    }
}
