using ProyectoSistemaClinico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoSistemaClinico.Data;
using System.Linq.Expressions;

namespace ProyectoSistemaClinico.Services
{
    public class HistorialClinicoService
    {
        private readonly ApplicationDbContext _context;

        public HistorialClinicoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearHistorialClinico(HistorialClinico historialClinico)
        {
            _context.HistorialClinico.Add(historialClinico);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ValidarHistorialClinicoExistente(int id, string nombrePaciente)
        {
            return await _context.HistorialClinico.AnyAsync(h => h.HistorialClinicoId == id && h.NombrePaciente == nombrePaciente);
        }

        public async Task<HistorialClinico> ObtenerHistorialClinicoPorId(int id)
        {
            return await _context.HistorialClinico.FindAsync(id);
        }



     

        public async Task<bool> ModificarHistorialClinico(HistorialClinico historialClinico)
        {
            _context.Entry(historialClinico).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(HistorialClinico historialClinico)
        {
            if (historialClinico == null)
            {
                throw new ArgumentNullException(nameof(historialClinico));
            }

            try
            {
                // Eliminar los detalles del historial clínico primero
                if (historialClinico.HistorialClinicoDetalle != null && historialClinico.HistorialClinicoDetalle.Any())
                {
                    foreach (var detalle in historialClinico.HistorialClinicoDetalle)
                    {
                        _context.HistorialClinicoDetalle.Remove(detalle);
                    }
                    await _context.SaveChangesAsync();
                }

                // Luego eliminar el historial clínico principal
                _context.HistorialClinico.Remove(historialClinico);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                // Manejar cualquier excepción aquí si es necesario
                return false;
            }
        }


        public async Task<List<HistorialClinico>> ObtenerTodos()
        {
            return await _context.HistorialClinico.ToListAsync();
        }


        public async Task<List<HistorialClinico>> Listar(Expression<Func<HistorialClinico, bool>> criterio)
        {
            return await _context.HistorialClinico
                .Where(criterio)
                .ToListAsync();
        }


    }
}


