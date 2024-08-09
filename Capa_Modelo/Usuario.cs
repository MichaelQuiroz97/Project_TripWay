using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Usuario
    {
        public string CedulaUsuario { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string PaisResidencia { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasenia { get; set; }
    }

}
