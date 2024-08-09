using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class Pai
{
    public int PaisId { get; set; }

    public string Nombre { get; set; } = null!;

    public string CodigoPais { get; set; } = null!;

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();
}
