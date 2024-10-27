using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TallerGestion.Models;
using Microsoft.EntityFrameworkCore;
using TallerGestion.Data.Persistence;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

public class OficinasComercialService
{
    private readonly GestionContext _context;
    public static Oficinascomerciales OficinaActual { get; set; }
    public OficinasComercialService(GestionContext context)
    {
        _context = context;
    }

    public async Task<List<Oficinascomerciales>> GetAllOficinasAsync()
    {
        return await _context.Oficinascomerciales.ToListAsync();
    }

    public async Task AddOficinaAsync(Oficinascomerciales oficina)
    {
        _context.Oficinascomerciales.Add(oficina);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteOficinaAsync(int id)
    {
        var oficina = await _context.Oficinascomerciales.FindAsync(id);
        if (oficina != null)
        {
            try
            {

                _context.Oficinascomerciales.Remove(oficina);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _context.ChangeTracker.Clear();
            }
        }
        return false;
    }

    public async Task<Oficinascomerciales> GetOficinaByIdAsync(int id)
    {
        return await _context.Oficinascomerciales.FindAsync(id);
    }
    public async Task UpdateOficinaAsync(Oficinascomerciales oficina)
    {
        _context.Entry(oficina).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    public async Task<List<PuestoAtencion>> GetPuestosatencionOficina(int oficinaId)
    {
        return await _context.Puestosatencion
                             .Where(p => p.OficinaId == oficinaId)
                             .ToListAsync();
    }

}
