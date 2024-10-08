﻿using System;
using System.Collections.Generic;

namespace TallerGestion.Models;

public partial class Clientes
{
    public int ClienteId { get; set; }

    public string CedulaIdentidad { get; set; }

    public virtual ICollection<Atenciones> Atenciones { get; set; } = new List<Atenciones>();
}
