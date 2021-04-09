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
    public class AdmisionsController : Controller
    {
        private SG_ASP_1Context db = new SG_ASP_1Context();

        // GET: Admisions
        public ActionResult Index()
        {
            var admision = db.Admision.Include(a => a.Atenciones);
            return View(admision.ToList());
        }

        // GET: Admisions/Details/5
        public ActionResult Details(int? Id)
        {

            var atenciones = db.Atenciones.Find(Id);
            //ViewBag.Medicina = atenciones.Medicina;
            return View(atenciones);
        }

        // GET: Admisions/Create
        [Authorize(Roles = "Admision,Admin")]
        public ActionResult Create(int Id)
        {
            var ate = db.Atenciones.Find(Id);
            var adm = new AdmisionCreateViewModel();
            List<Interconsulta> inter = new List<Interconsulta>();

            adm.AtenId = ate.Id;
            adm.DocIde = ate.DocIde;
            adm.Empres = ate.Empres;
            adm.NomApe = ate.NomApe;
            adm.HorIng = ate.Hora;
            adm.HorSal = TimeSpan.Parse(DateTime.Now.ToShortTimeString());

            if (ate.Admision!=null)
            {
                foreach (var item in ate.Admision)
                {
                    adm.Id = item.Id;
                    adm.HorIng = item.HorIng;
                    adm.HorSal = item.HorSal;
                    adm.Pendie = item.Pendie;
                }
            }

            foreach (var item in ate.Interconsulta)
            {
                inter.Add(item);
            }

            adm.interconsultas = inter;

            return View(adm);
     
        }

        // POST: Admisions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admision,Admin")]
        public ActionResult Create( AdmisionCreateViewModel admisionVM)
        {
            
                var adm = new Admision();
                var ate = db.Atenciones.Find(admisionVM.AtenId);
                adm.AtenId = admisionVM.AtenId;
                adm.HorIng = admisionVM.HorIng;
                adm.HorSal = admisionVM.HorSal;
                adm.Pendie = admisionVM.Pendie;
                adm.Usuari = "lorem";
                adm.UserName = HttpContext.User.Identity.Name;

            if (ate.Admision.Count>0)
            {
                foreach (var item in ate.Admision)
                {
                    item.HorIng = admisionVM.HorIng;
                    item.HorSal = admisionVM.HorSal;
                    item.Pendie = admisionVM.Pendie;

                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                db.Admision.Add(adm);
                db.SaveChanges();
            }

                
                if (admisionVM.interconsultas != null)
                {
                    foreach (var item in admisionVM.interconsultas)
                    {
                        item.AtenId = admisionVM.AtenId;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index", "Atenciones");
        }
       
        public ActionResult Atenciones() 
        {
            return RedirectToAction("Index", "Atenciones");
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
