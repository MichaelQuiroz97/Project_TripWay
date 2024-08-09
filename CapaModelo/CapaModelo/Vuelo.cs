using System;
using System.Collections.Generic;

namespace BETripWay.CapaNegocio;

public partial class Vuelo
{
    public int Id { get; set; }

    public string Nvuelo { get; set; } = null!;

    public int Naeropuerto { get; set; }

    public DateTime Fpartida { get; set; }

    public int? Corigen { get; set; }

    public int? Cdestino { get; set; }

    public bool Nocturno { get; set; }

    public virtual Cdestino? CdestinoNavigation { get; set; }

    public virtual Ciudad? CorigenNavigation { get; set; }

    public virtual Aeropuerto NaeropuertoNavigation { get; set; } = null!;
}
