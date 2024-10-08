using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TallerGestion.Models;
using Microsoft.EntityFrameworkCore;
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
}
