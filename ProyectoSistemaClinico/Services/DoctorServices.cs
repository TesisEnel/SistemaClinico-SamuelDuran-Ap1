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
    public class DoctorService
    {
        private readonly ApplicationDbContext _context;

        public DoctorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearDoctor(Doctor doctor)
        {
            _context.Doctor.Add(doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ValidarDoctorExistente(int id)
        {
            return await _context.Doctor.AnyAsync(d => d.DoctorId == id);
        }

        public async Task<Doctor> ObtenerDoctorPorId(int id)
        {
            return await _context.Doctor.FindAsync(id);
        }

        public async Task<bool> ModificarDoctor(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(Doctor doctor)
        {
            _context.Doctor.Remove(doctor);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Doctor>> ObtenerTodos()
        {
            return await _context.Doctor.ToListAsync();
        }


        public async Task<List<Doctor>> Listar(Expression<Func<Doctor, bool>> criterio)
        {
            return await _context.Doctor
                .Where(criterio)
                .ToListAsync();
        }
    }
}
