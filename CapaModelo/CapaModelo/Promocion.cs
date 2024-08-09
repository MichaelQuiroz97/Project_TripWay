using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class Promocion
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Destino { get; set; } = null!;

    public decimal Precio { get; set; }
}
