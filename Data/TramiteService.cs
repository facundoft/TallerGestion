using System.Threading.Tasks;
using TallerGestion.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TallerGestion.Data.Persistence;
using System.Linq;
using System;
using Microsoft.AspNetCore.SignalR;

namespace TallerGestion.Data
{
    public class TramiteService
    {
        private readonly GestionContext _context;

        public TramiteService(GestionContext context)
        {
            _context = context;
        }
        public async Task<List<Tramite>> GetTramites() {
            return await _context.Tramite.ToListAsync();

        }
        public async Task<List<Tramite>> GetTramites(List<int> ID)
        {
            return await _context.Tramite
                .Where(t=> ID.Contains(t.TramiteId))
                .ToListAsync();

        }
    }
}
