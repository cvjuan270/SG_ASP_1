namespace SG_ASP_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medicina")]
    public partial class Medicina
    {
        public int Id { get; set; }

        public int? AtenId { get; set; }

        public TimeSpan? HorIng { get; set; }

        public TimeSpan? HorSal { get; set; }

        [StringLength(50)]
        public string Medico { get; set; }

        [StringLength(50)]
        public string Aptitu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FecApt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FecEnv { get; set; }

        [StringLength(100)]
        public string Coment { get; set; }

        [StringLength(100)]
        public string Observ { get; set; }

        public int? Alerta { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        public virtual Atenciones Atenciones { get; set; }
    }
}
