using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoSistemaClinico.Models;

namespace ProyectoSistemaClinico.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Citas> Citas { get; set; }

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<HistorialClinico> HistorialClinico { get; set; }
        public DbSet<HistorialClinicoDetalle> HistorialClinicoDetalle { get; set; }
    }
}
