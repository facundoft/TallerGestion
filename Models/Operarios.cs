using System;
using System.Collections.Generic;

namespace TallerGestion.Models;

public partial class Operarios
{
    public int OperarioId { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public int? OficinaId { get; set; }

    public virtual Oficinascomerciales Oficina { get; set; }
}
