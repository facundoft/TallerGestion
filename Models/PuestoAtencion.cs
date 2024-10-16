using System;
using System.Collections.Generic;

namespace TallerGestion.Models;

public partial class PuestoAtencion
{
    public int PuestoId { get; set; }

    public int? OficinaId { get; set; }

    public int? NumeroPuesto { get; set; }

    public virtual Oficinascomerciales Oficina { get; set; }
}
