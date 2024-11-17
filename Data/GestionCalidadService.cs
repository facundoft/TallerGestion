using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TallerGestion.Data.Persistence;
using TallerGestion.Models;

namespace TallerGestion.Data
{
    public class GestionCalidadService
    {

        private readonly GestionContext _context;
        public GestionCalidadService(GestionContext context)
        {
            _context = context;
        }

        public static decimal TiempoPromedioAtencion(DateTime startDate, DateTime endDate)
        {
            return 1;
        }
        public static uint CantidadClientesAtendidosTiempo(DateTime startDate, DateTime endDate)
        {
            return 1;
        }
        public async Task<List<CantAtencionesTramite>> GetCantAtencionesTramites()
        {
            return await _context.CantAtencionesTramite.ToListAsync();
        }
    }
}
