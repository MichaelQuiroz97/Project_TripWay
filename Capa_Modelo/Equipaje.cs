using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Equipaje
    {
        public string Id { get; set; }
        public string CedulaUsuario { get; set; } 
        public Usuario Usuario { get; set; }
        public double Peso { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
    }

}
