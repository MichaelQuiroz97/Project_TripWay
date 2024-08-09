using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class Pasajero
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public int Cantidad { get; set; }

    public int? ReservaId { get; set; }

    public virtual Reserva? Reserva { get; set; }
}
