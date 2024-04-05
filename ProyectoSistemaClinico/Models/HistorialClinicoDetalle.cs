using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoSistemaClinico.Models
{
    public class HistorialClinicoDetalle
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Dieta")]
        public string Dieta { get; set; }

        [Display(Name = "Ejercicio Físico")]
        public string EjercicioFisico { get; set; }

        [Display(Name = "Consumo de Alcohol")]
        public string ConsumoAlcohol { get; set; }

        [Display(Name = "Otra Información Relevante")]
        public string OtraInformacionRelevante { get; set; }
    }

  
}
