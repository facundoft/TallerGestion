using System;
using System.Collections.Generic;

namespace TallerGestion.Models;

public partial class Tramite
{
    public int TramiteId { get; set; }

    public string DescripcionTramite { get; set; }

    public virtual ICollection<Atenciones> Atenciones { get; set; } = new List<Atenciones>();
}
