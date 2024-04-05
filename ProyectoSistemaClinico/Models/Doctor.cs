using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoSistemaClinico.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        public string NombreCompleto { get; set; }

        public DateTime FechaDeCreacion { get; set; }
        public string EspecialidadMedica { get; set; }

        public string HorarioDisponibilidad { get; set; }
    }

    
}
