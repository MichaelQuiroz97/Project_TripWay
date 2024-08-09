using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class Ciudad
{
    public int IdCiudad { get; set; }

    public string Nombre { get; set; } = null!;

    public int? PaisId { get; set; }

    public virtual ICollection<Aeropuerto> Aeropuertos { get; set; } = new List<Aeropuerto>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual Pai? Pais { get; set; }

    public virtual ICollection<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
}
