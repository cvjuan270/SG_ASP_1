using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SG_ASP_1.Models
{
    public class MedicinaCreateViewModel
    {
        #region Atenciones
        [Display(Name = "ID")]
        public int oAteId { get; set; }

        [StringLength(20)]
        [Display(Name = "Tip. Examen")]
        public string TipExa { get; set; }

        [StringLength(100)]
        [Display(Name = "Nombres y Apellidos")]
        public string NomApe { get; set; }

        [StringLength(20)]
        [Display(Name = "Doc. de Identidad")]
        public string DocIde { get; set; }

        [StringLength(100)]
        [Display(Name = "Empresa")]
        public string Empres { get; set; }
        #endregion

        #region Medicina


        public int AtenId { get; set; }

        [Display(Name = "Hora de ingreso")]
        [DataType(DataType.Time)]
        public TimeSpan? HorIng { get; set; }

        [Display(Name = "Hora de salida")]
        [DataType(DataType.Time)]
        public TimeSpan? HorSal { get; set; }

        [StringLength(50)]
        public string Medico { get; set; }

        [StringLength(50,ErrorMessage = "El {0} debe contener como maximo 50 caracteres.")]
        [Display(Name = "Aptitud")]
        public string Aptitu { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Aptitud")]
        public DateTime? FecApt { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de envio de resultados")]
        public DateTime? FecEnv { get; set; }

        [StringLength(100)]
        [Display(Name = "Comentarios")]
        public string Coment { get; set; }

        [StringLength(100)]
        [Display(Name = "Observaciones")]
        public string Observ { get; set; }
        #endregion

        #region Interconsulta

        public List<Interconsulta> interconsultas { get; set; }

        #endregion
    }

    public class MedicinaDetailsViewModel
    {
        public string hola { get; set; }
    }
}