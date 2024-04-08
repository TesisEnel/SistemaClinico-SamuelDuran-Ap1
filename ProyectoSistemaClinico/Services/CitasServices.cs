using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProyectoSistemaClinico.Data;
using ProyectoSistemaClinico.Models;

namespace ProyectoSistemaClinico.Services
{
    public class CitasService
    {
        private readonly ApplicationDbContext _context;

        public CitasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Crear(Citas cita)
        {
            if (await ExisteCita(cita))
            {
                return false; 
            }
            else
            {
                return await Insertar(cita);
            }
        }

        private async Task<bool> ExisteCita(Citas cita)
        {
            return await _context.Citas
                .AnyAsync(c => c.FechaHora == cita.FechaHora);
        }

        private async Task<bool> Insertar(Citas cita)
        {
            try
            {
                _context.Citas.Add(cita);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar la cita: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> Modificar(Citas cita)
        {
            _context.Update(cita);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(Citas cita)
        {
            _context.Citas.Remove(cita);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Citas> BuscarPorId(int citaId)
        {
            return await _context.Citas.FindAsync(citaId);
        }


        public async Task<List<Citas>> ObtenerTodos()
        {
            return await _context.Citas.ToListAsync();
        }

        public async Task<List<Citas>> Listar(Expression<Func<Citas, bool>> criterio)
        {
            return await _context.Citas
                .Where(criterio)
                .ToListAsync();
        }
    }
}
