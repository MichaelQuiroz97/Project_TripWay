using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class Comentario
{
    public int Id { get; set; }

    public string ComentarioTexto { get; set; } = null!;

    public string? CedulaUsuario { get; set; }

    public virtual Usuario? CedulaUsuarioNavigation { get; set; }
}
