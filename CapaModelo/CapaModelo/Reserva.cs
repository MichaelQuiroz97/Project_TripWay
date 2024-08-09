using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class Reserva
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateTime FechaIda { get; set; }

    public DateTime FechaRegreso { get; set; }

    public string CiudadOrigen { get; set; } = null!;

    public string Destino { get; set; } = null!;

    public int Viaje { get; set; }

    public string Clase { get; set; } = null!;

    public virtual ICollection<Pasajero> Pasajeros { get; set; } = new List<Pasajero>();
}
