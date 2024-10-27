using System.Threading.Tasks;
using TallerGestion.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TallerGestion.Data.Persistence;
using System.Linq;
using System;
using Microsoft.AspNetCore.SignalR;
using TallerGestion.Hubs;
using Microsoft.AspNetCore.Mvc.Rendering;
using Google.Protobuf.Compiler;

namespace TallerGestion.Data
{
    public class AtencionesService
    {
        private readonly GestionContext _context;
        private readonly IHubContext<AtencionHub> _hubContext;

        public AtencionesService(GestionContext context, IHubContext<AtencionHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<int> CrearNuevaAtencionAsync(Atenciones atencion)
        {
            try
            {

                // Agregar la nueva atención a la base de datos
                _context.Atenciones.Add(atencion);
                await _context.SaveChangesAsync();

                // Notificar a los clientes conectados sobre la nueva atención
                await _hubContext.Clients.All.SendAsync("NuevaAtencion", atencion.OficinaId);
                return atencion.AtencionId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
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



        public async Task<Clientes> ObtenerEstadoAtencion(string cedula)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.CedulaIdentidad == cedula);
        }

        //public async Task<string> ObtenerEstadoAtencionAsync(string cedula)
        //{
        //    var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.CedulaIdentidad == cedula);
        //    if (cliente == null)
        //    {
        //        return null; // Cliente no encontrado
        //    }

        //    var atencion = await _context.Atenciones
        //        .Where(a => a.ClienteId == cliente.ClienteId)
        //        .OrderByDescending(a => a.FechaHoraLlegada) // Ordenar por la fecha de llegada para obtener la atención más reciente
        //        .FirstOrDefaultAsync();

        //    return atencion?.Estado; // Devolver el estado de la atención o null si no hay atenciones
        //}

        public async Task<string> ObtenerEstadoAtencionPorCedulaAsync(string cedula)
        {
            // Verificar el valor de cedula
            Console.WriteLine($"Cedula: {cedula}");

            string query = @"
                            SELECT a.Estado
                            FROM clientes c
                            LEFT JOIN atenciones a ON c.ClienteID = a.ClienteID
                            WHERE c.CedulaIdentidad = {0}";

            var resultado = await _context.Atenciones
                .FromSqlRaw(query, cedula)
                .Select(a => a.Estado)
                .FirstOrDefaultAsync();

            //Console.WriteLine($"Resultado: {resultado}");
            //System.Diagnostics.Debug.WriteLine("\n\n DATOSSS \n\n"+resultado);
            return resultado;
        }


        public async Task<IQueryable<Atenciones>> GetAtencionesAsyncFilter(DateTime DateStart, DateTime DateFinish, string FiltroEstado = "todos")
        {
            var query = _context.Atenciones
                .Include(a => a.Cliente)
                .Include(a => a.Oficina)
                .Include(a => a.Puesto)
                .Include(a => a.Operario)
                .Include(a => a.Tramite)
                .Where(a => a.FechaHoraLlegada > DateStart && a.FechaHoraLlegada < DateFinish);

            if (FiltroEstado != "todos")
            {
                query = query.Where(a => a.Estado == FiltroEstado);
            }
            return query.AsQueryable();
        }

        public async Task<IQueryable<Atenciones>> GetAtencionesAsyncFilterWithJoins(DateTime DateStart, DateTime DateFinish, string FiltroEstado = "todos")
        {
            var query = _context.Atenciones
                .Include(a => a.Cliente)
                .Include(a => a.Oficina)
                .Include(a => a.Puesto)
                .Include(a => a.Operario)
                .Include(a => a.Tramite)
                .Where(a => a.FechaHoraLlegada > DateStart && a.FechaHoraLlegada < DateFinish);

            if (FiltroEstado != "todos")
            {
                query = query.Where(a => a.Estado == FiltroEstado);
            }

            return query.AsQueryable();
        }
    }
}
