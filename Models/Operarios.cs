using System;
using System.Collections.Generic;

namespace TallerGestion.Models;

public partial class Operarios
{
    public int OperarioId { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public int? OficinaId { get; set; }

    public virtual ICollection<Atenciones> Atenciones { get; set; } = new List<Atenciones>();

    public virtual Oficinascomerciales Oficina { get; set; }
}
