using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoSistemaClinico.Models
{
    public class HistorialClinicoDetalle
    {
        [Key]
        public int Id { get; set; }

        public string Dieta { get; set; }

        public string EjercicioFisico { get; set; }

        public string ConsumoAlcohol { get; set; }

        public string OtraInformacionRelevante { get; set; }
    }

  
}
