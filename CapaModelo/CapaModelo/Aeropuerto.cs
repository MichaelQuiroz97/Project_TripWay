using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class Aeropuerto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Abreviatura { get; set; } = null!;

    public int Ciudad { get; set; }

    public bool Transporte { get; set; }

    public virtual Ciudad CiudadNavigation { get; set; } = null!;

    public virtual ICollection<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
    public string CiudadNombre { get; set; }
}
