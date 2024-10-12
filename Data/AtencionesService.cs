using System.Threading.Tasks;
using TallerGestion.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TallerGestion.Data.Persistence;

namespace TallerGestion.Data
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


        // Verificar si el cliente existe
        public async Task<Clientes> ObtenerClientePorCedulaAsync(string cedula)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.CedulaIdentidad == cedula);
        }

        // Crear un nuevo cliente si no existe
        public async Task<Clientes> CrearClienteAsync(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        // Función para obtener todos los trámites disponibles
        public async Task<List<Tramite>> ObtenerTramitesAsync()
        {
            return await _context.Tramite.ToListAsync();
        }

    }
}
