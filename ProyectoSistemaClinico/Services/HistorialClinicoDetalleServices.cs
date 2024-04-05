using Microsoft.EntityFrameworkCore;
using ProyectoSistemaClinico.Data;
using ProyectoSistemaClinico.Models;
using System.Linq.Expressions;

namespace ProyectoSistemaClinico.Services
{
    public class HistorialClinicoDetalleService
    {
        private readonly ApplicationDbContext _context;

        public HistorialClinicoDetalleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearHistorialClinicoDetalle(HistorialClinicoDetalle historialClinicoDetalle)
        {
            _context.HistorialClinicoDetalle.Add(historialClinicoDetalle);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ValidarHistorialClinicoDetalleExistente(int id)
        {
            return await _context.HistorialClinicoDetalle.AnyAsync(h => h.Id == id);
        }

        public async Task<HistorialClinicoDetalle> ObtenerHistorialClinicoDetallePorId(int id)
        {
            return await _context.HistorialClinicoDetalle.FindAsync(id);
        }

        public async Task<bool> ModificarHistorialClinicoDetalle(HistorialClinicoDetalle historialClinicoDetalle)
        {
            _context.Entry(historialClinicoDetalle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(HistorialClinicoDetalle historialClinicoDetalle)
        {
            _context.HistorialClinicoDetalle.Remove(historialClinicoDetalle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<HistorialClinicoDetalle>> ObtenerTodos()
        {
            return await _context.HistorialClinicoDetalle.ToListAsync();
        }


        public async Task<List<HistorialClinicoDetalle>> Listar(Expression<Func<HistorialClinicoDetalle, bool>> criterio)
        {
            return await _context.HistorialClinicoDetalle
                .Where(criterio)
                .ToListAsync();
        }
    }
}

