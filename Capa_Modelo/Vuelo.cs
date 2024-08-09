using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Vuelo
    {
        public int Id { get; set; }
        public string NVuelo { get; set; }
        public string NAeropuerto { get; set; }
        public DateTime FPartida { get; set; }
        public int Corigen { get; set; } // Foreign key to Ciudad
        public Ciudad Origen { get; set; } // Navigation property
        public int CDestino { get; set; } // Foreign key to Ciudad
        public Ciudad Destino { get; set; } // Navigation property
        public bool Nocturno { get; set; }
    }

}
