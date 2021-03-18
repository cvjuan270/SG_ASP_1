namespace SG_ASP_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admision")]
    public partial class Admision
    {
        public int Id { get; set; }

        public int? AtenId { get; set; }

        public TimeSpan? HorIng { get; set; }

        public TimeSpan? HorSal { get; set; }

        [Required]
        [StringLength(10)]
        public string Usuari { get; set; }

        [StringLength(200)]
        public string Pendie { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        public virtual Atenciones Atenciones { get; set; }
    }
}
