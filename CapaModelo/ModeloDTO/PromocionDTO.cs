using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.ModeloDTO
{
    public class PromocionDTO
    {

        public string Titulo { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public string Destino { get; set; } = null!;

        public decimal Precio { get; set; }

    }
}
