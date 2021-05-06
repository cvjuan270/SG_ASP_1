namespace SG_ASP_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Auditoria")]
    public partial class Auditoria
    {
        public Auditoria() 
        {
            ExaMedicos = new List<ExaMedico>();
        }
        public int Id { get; set; }

        public int? AtenId { get; set; }

        [Display(Name ="Examenes Incompletos")]
        public bool ExaCom { get; set; }

        public virtual ICollection<ExaMedico> ExaMedicos { get; set; }

        [StringLength(20)]
        public string ExaCom1 { get; set; }

        [Display(Name ="Datos incompletos")]
        public bool DatInc { get; set; }

        [StringLength(20)]
        public string DatInc1 { get; set; }

        [Display(Name = "Aptitud errada")]
        public bool AptErr { get; set; }

        [StringLength(20)]
        public string AptErr1 { get; set; }

        [Display(Name = "Falta firma del m�dico")]
        public bool FaFiMe { get; set; }

        [StringLength(20)]
        public string FaFiMe1 { get; set; }

        [Display(Name = "Falta firma del paciente")]
        public bool FaFiPa { get; set; }

        [StringLength(20)]
        public string FaFiPa1 { get; set; }

        [Display(Name = "Restricciones")]
        public bool Restri { get; set; }

        [StringLength(20)]
        public string Restri1 { get; set; }

        [Display(Name = "Controles")]
        public bool Contro { get; set; }

        [StringLength(20)]
        public string Contro1 { get; set; }

        [Display(Name = "Diagn�stico")]
        public bool Diagno { get; set; }

        [StringLength(20)]
        public string Diagno1 { get; set; }

        [Display(Name = "Error de llenado")]
        public bool ErrLle { get; set; }

        [StringLength(20)]
        public string ErrLle1 { get; set; }

        [StringLength(100)]
        [Display(Name = "Observaciones")]
        public string ObNoRe { get; set; }

        [Display(Name = "Emo sin observaciones")]
        public bool EmSnOb { get; set; }

        [StringLength(20)]
        public string EmSnOb1 { get; set; }

        
        [DataType(DataType.Time)]
        [Display(Name = "Hora de auditor�a")]
        public TimeSpan? HorAud { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de auditor�a")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FecAud { get; set; }

        public int? Alerta { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Medico { get; set; }

        [Display(Name = "Omisi�n de interconsulta")]
        public bool OmiInt { get; set; }

        [StringLength(20)]
        public string OmiInt1 { get; set; }

        public virtual Atenciones Atenciones { get; set; }

        
    }
}
