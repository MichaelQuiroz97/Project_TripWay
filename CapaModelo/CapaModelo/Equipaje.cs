using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class Equipaje
{
    public int Id { get; set; }

    public string? CedulaUsuario { get; set; }

    public double Peso { get; set; }

    public string Tipo { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual Usuario? CedulaUsuarioNavigation { get; set; }
}
