using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Aeropuerto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public bool Transporte { get; set; }
    }

}
