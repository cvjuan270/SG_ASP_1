using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SG_ASP_1.Models
{
    public class ExaMedico
    {
        public int Id { get; set; }
        public String Examen { get; set; }
        public virtual ICollection<Auditoria> Auditorias { get; set; }
    }
}