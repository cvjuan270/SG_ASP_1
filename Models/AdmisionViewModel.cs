using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SG_ASP_1.Models
{
    public class AdmisionCreateViewModel
    {
        #region Atenciones

        public string NomApe { get; set; }
        public string DocIde { get; set; }
        public string Empres { get; set; }
        #endregion
        public int Id { get; set; }

        public int? AtenId { get; set; }

        [DataType(DataType.Time)]
        [Display(Name ="Hora de ingreso")]
        public TimeSpan? HorIng { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora de salida")]
        public TimeSpan? HorSal { get; set; }

        [Required]
        [StringLength(10)]
        public string Usuari { get; set; }

        [StringLength(200)]
        [Display(Name = "Pendientes")]
        public string Pendie { get; set; }

        public List<Interconsulta> interconsultas { get; set; }
    }
}