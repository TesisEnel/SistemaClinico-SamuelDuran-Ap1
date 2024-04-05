using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoSistemaClinico.Models
{
    public class Citas
    {
        [Key]
        public int CitasId { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del paciente.")]
        public string NombrePaciente { get; set; }


        [Required(ErrorMessage = "Debe ingresar la fecha y hora de la cita.")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del médico.")]
        public string NombreMedico { get; set; }

        [Required(ErrorMessage = "Debe ingresar la razón de la cita.")]
        public string RazonCita { get; set; }

      

       
    }
}
