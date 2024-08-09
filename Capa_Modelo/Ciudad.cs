using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Ciudad
    {
        public int IdCiudad { get; set; }
        public string Nombre { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
    }

}
