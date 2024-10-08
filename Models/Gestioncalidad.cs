using System;
using System.Collections.Generic;

namespace TallerGestion.Models;

public partial class Gestioncalidad
{
    public int GestionCalidadId { get; set; }

    public int? OficinaId { get; set; }

    public DateTime? Fecha { get; set; }

    public int? TiempoPromedioAtencion { get; set; }

    public int? CantidadClientesAtendidos { get; set; }

    public int? TiempoPromedioEspera { get; set; }

    public virtual Oficinascomerciales Oficina { get; set; }
}
