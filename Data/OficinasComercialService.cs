using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TallerGestion.Models;
using Microsoft.EntityFrameworkCore;
using TallerGestion.Data.Persistence;
public class OficinasComercialService
{
    private readonly GestionContext _context;

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

    public async Task DeleteOficinaAsync(int id)
    {
        var oficina = await _context.Oficinascomerciales.FindAsync(id);
        if (oficina != null)
        {
            _context.Oficinascomerciales.Remove(oficina);
            await _context.SaveChangesAsync();
        }
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
}
