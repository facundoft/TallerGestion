using System;
using System.Collections.Generic;

namespace TallerGestion.Models;

public partial class Atenciones
{
    public int AtencionId { get; set; }

    public int? ClienteId { get; set; }

    public int? OficinaId { get; set; }

    public int? PuestoId { get; set; }

    public int? OperarioId { get; set; }

    public int? TramiteId { get; set; }

    public DateTime? FechaHoraLlegada { get; set; }

    public DateTime? FechaHoraAtencion { get; set; }

    public DateTime? FechaHoraFinalizacion { get; set; }

    public string Estado { get; set; }

    public sbyte? SegundaLlamado { get; set; }

    public string DescripcionTramite { get; set; }

    public virtual Clientes Cliente { get; set; }

    public virtual Oficinascomerciales Oficina { get; set; }

    public virtual Operarios Operario { get; set; }

    public virtual Puestosatencion Puesto { get; set; }
}
