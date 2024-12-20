﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TallerGestion.Models;
using TallerGestion.Data.Persistence;

public class PuestosAtencionService
{
    private readonly GestionContext _context;

    public PuestosAtencionService(GestionContext context)
    {
        _context = context;
    }
    /*
    public async Task<List<Puestosatencion>> GetAllPuestosAsync()
    {
        return await _context.Puestosatencion.ToListAsync();
    }
    */
    public async Task AddPuestoAsync(PuestoAtencion puesto)
    {
        _context.Puestosatencion.Add(puesto);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeletePuestoAsync(int id)
    {
        var puesto = await _context.Puestosatencion.FindAsync(id);
        if (puesto != null)
        {
            try
            {
                _context.Puestosatencion.Remove(puesto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _context.ChangeTracker.Clear();
            }
        }
        return false;
    }
}
