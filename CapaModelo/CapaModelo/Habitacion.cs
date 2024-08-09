using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class Habitacion
{
    public int IdHabitaciones { get; set; }

    public int? IdHotel { get; set; }

    public int Capacidad { get; set; }

    public string TipoHabitacion { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? CedulaUsuario { get; set; }

    public bool Estado { get; set; }

    public virtual Usuario? CedulaUsuarioNavigation { get; set; }

    public virtual Hotel? IdHotelNavigation { get; set; }
}
