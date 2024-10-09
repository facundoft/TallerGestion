using System;
using System.Collections.Generic;

namespace TallerGestion.Models;

public partial class Oficinascomerciales
{
    public int OficinaId { get; set; }

    public string Nombre { get; set; }

    public string Direccion { get; set; }

    public string Ciudad { get; set; }

    public virtual ICollection<Operarios> Operarios { get; set; } = new List<Operarios>();

    public virtual ICollection<Puestosatencion> Puestosatencion { get; set; } = new List<Puestosatencion>();
}
