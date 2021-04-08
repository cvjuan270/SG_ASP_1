using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SG_ASP_1.Models
{
    public class EnfermeriaViewModel
    {
        #region Atenciones

        [Display(Name = "Nombre y Apellido")]
        public string NomApe { get; set; }

        [Display(Name = "Documento de identidad")]
        public string DocIde { get; set; }

        [Display(Name = "Empresa")]
        public string Empres { get; set; }
        #endregion
        public int Id { get; set; }
        [Display(Name = "Id")]
        public int? AtenId { get; set; }
        public List<Interconsulta> interconsultas { get; set; }
    }
}