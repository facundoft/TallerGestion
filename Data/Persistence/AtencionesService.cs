using System.Threading.Tasks;
using TallerGestion.Models;
using Microsoft.EntityFrameworkCore;

namespace TallerGestion.Data.Persistence
{
    public class AtencionesService
    {
        private readonly GestionContext _context;

        public AtencionesService(GestionContext context)
        {
            _context = context;
        }

        public async Task CrearNuevaAtencionAsync(Atenciones atencion)
        {
            // Agregar la nueva atención a la base de datos
            _context.Atenciones.Add(atencion);
            await _context.SaveChangesAsync();
        }

    }
}
