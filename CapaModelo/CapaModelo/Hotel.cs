using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class Hotel
{
    public int IdHotel { get; set; }

    public int? IdCiudad { get; set; }

    public string Direccion { get; set; } = null!;

    public int Nhabitaciones { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();

    public virtual Ciudad? IdCiudadNavigation { get; set; }
}
