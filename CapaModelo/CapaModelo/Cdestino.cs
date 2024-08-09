using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class Cdestino
{
    public int Id { get; set; }

    public string Valor { get; set; } = null!;

    public virtual ICollection<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
}
