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

    public virtual Clientes Cliente { get; set; }

    public virtual Oficinascomerciales Oficina { get; set; }

    public virtual Operarios Operario { get; set; }

    public virtual PuestoAtencion Puesto { get; set; }

    public virtual Tramite Tramite { get; set; }

    public Atenciones()
    {
    }

    public string GetPuesto()
    {
        if (Puesto != null)
        {
            return Puesto.NumeroPuesto.ToString();
        }
        else return "";
    }

    public string GetNombreOperario()
    {
        if (Operario != null)
        {
            return Operario.Nombre + " " + Operario.Apellido;
        }
        else return "";
    }

    public Atenciones(int? clientId, int? oficinaId, int? puestoId, int? operarioId, int? tramiteId, DateTime? fechaHoraLlegada, DateTime? fechaHoraAtencion, DateTime? fechaHoraFinalizacion, string estado, sbyte? segundaLlamado)
    {
        ClienteId = clientId;
        OficinaId = oficinaId;
        PuestoId = puestoId;
        OperarioId = operarioId;
        TramiteId = tramiteId;
        FechaHoraLlegada = fechaHoraLlegada;
        FechaHoraAtencion = fechaHoraAtencion;
        FechaHoraFinalizacion = fechaHoraFinalizacion;
        Estado = estado;
        SegundaLlamado = segundaLlamado;
    }
}
