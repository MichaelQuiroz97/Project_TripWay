using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class MetodoPago
{
    public int Id { get; set; }

    public string NombreTitular { get; set; } = null!;

    public string NumeroTarjeta { get; set; } = null!;

    public string Expiracion { get; set; } = null!;

    public string Cvc { get; set; } = null!;
}
