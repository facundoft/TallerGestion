using System;
using System.Collections.Generic;

namespace TallerGestion.Models;

public partial class Puestosatencion
{
    public int PuestoId { get; set; }

    public int? OficinaId { get; set; }

    public int? NumeroPuesto { get; set; }

    public virtual ICollection<Atenciones> Atenciones { get; set; } = new List<Atenciones>();

    public virtual Oficinascomerciales Oficina { get; set; }
}
