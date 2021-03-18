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
        public int Id { get; set; }

        public int? AtenId { get; set; }

        public bool ExaCom { get; set; }

        [StringLength(20)]
        public string ExaCom1 { get; set; }

        public bool DatInc { get; set; }

        [StringLength(20)]
        public string DatInc1 { get; set; }

        public bool AptErr { get; set; }

        [StringLength(20)]
        public string AptErr1 { get; set; }

        public bool FaFiMe { get; set; }

        [StringLength(20)]
        public string FaFiMe1 { get; set; }

        public bool FaFiPa { get; set; }

        [StringLength(20)]
        public string FaFiPa1 { get; set; }

        public bool Restri { get; set; }

        [StringLength(20)]
        public string Restri1 { get; set; }

        public bool Contro { get; set; }

        [StringLength(20)]
        public string Contro1 { get; set; }

        public bool Diagno { get; set; }

        [StringLength(20)]
        public string Diagno1 { get; set; }

        public bool ErrLle { get; set; }

        [StringLength(20)]
        public string ErrLle1 { get; set; }

        [StringLength(100)]
        public string ObNoRe { get; set; }

        public bool EmSnOb { get; set; }

        [StringLength(20)]
        public string EmSnOb1 { get; set; }

        public TimeSpan? HorAud { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FecAud { get; set; }

        public int? Alerta { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        public virtual Atenciones Atenciones { get; set; }
    }
}
