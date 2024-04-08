using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSistemaClinico.Models
{
    public class HistorialClinico
    {
        [Key]
        public int HistorialClinicoId { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del paciente")]
        [Display(Name = "Nombre del Paciente")]
        public string NombrePaciente { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha de nacimiento del paciente")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe ingresar la dirección del paciente")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Historial de Enfermedades y Cirugías Previas")]
        public string HistorialEnfermedadesCirugias { get; set; }

        [Display(Name = "Alergias Conocidas")]
        public string Alergias { get; set; }

        [Display(Name = "Reacciones a las Alergias")]
        public string ReaccionesAlergias { get; set; }

        [Display(Name = "Medicamentos Actuales y Dosis")]
        public string MedicamentosActuales { get; set; }

        [Display(Name = "Resultados de Pruebas Médicas y Exámenes")]
        public string ResultadosPruebasMedicas { get; set; }

        [Display(Name = "Notas de Progreso y Seguimiento de Tratamientos Anteriores")]
        public string NotasProgresoSeguimiento { get; set; }

        public ICollection<HistorialClinicoDetalle> HistorialClinicoDetalle { get; set; } = new List<HistorialClinicoDetalle>();
    }

   
}
