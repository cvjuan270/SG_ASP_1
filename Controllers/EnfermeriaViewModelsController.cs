using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SG_ASP_1.Models;

namespace SG_ASP_1.Controllers
{
    public class EnfermeriaViewModelsController : Controller
    {
        private SG_ASP_1Context db = new SG_ASP_1Context();

        // GET: EnfermeriaViewModels/Create
        public ActionResult Create(int Id)
        {
            var ate = db.Atenciones.Find(Id);
            var enf = new EnfermeriaViewModel();
            List<Interconsulta> inter = new List<Interconsulta>();

            enf.AtenId = ate.Id;
            enf.DocIde = ate.DocIde;
            enf.NomApe = ate.NomApe;
            enf.Empres = ate.Empres;

            foreach (var item in ate.Interconsulta)
            {
                inter.Add(item);
            }
            enf.interconsultas = inter;

            return View(enf);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Enfermeria,Admin")]
        public ActionResult Create( EnfermeriaViewModel enf) 
        {
            if (enf.interconsultas!= null)
            {
                foreach (var item in enf.interconsultas)
                {
                    item.AtenId = enf.AtenId;
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
               return RedirectToAction("Index", "Atenciones");
            }
            else
            {
                return View(enf);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
