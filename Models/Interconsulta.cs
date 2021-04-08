namespace SG_ASP_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Interconsulta")]
    public partial class Interconsulta
    {
        public int Id { get; set; }

        public int? AtenId { get; set; }

        public int? NumLine { get; set; }

        [StringLength(50)]
        public string IntCon { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FecEnv { get; set; }

        [StringLength(50)]
        public string PeEnCo { get; set; }

        public bool EnHoIn { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? FeCoPa { get; set; }

        [StringLength(50)]
        public string PeCoPa { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FeLeObs { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        public virtual Atenciones Atenciones { get; set; }
    }
}
