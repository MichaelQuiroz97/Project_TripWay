using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class Usuario
{
    public string CedulaUsuario { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string PaisResidencia { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Equipaje> Equipajes { get; set; } = new List<Equipaje>();

    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();
}
