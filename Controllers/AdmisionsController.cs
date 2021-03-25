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

            //if (Id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //var ate = db.Atenciones.Find(Id);
            //var adm = new Admision();
            //List<Interconsulta> inter = new List<Interconsulta>();
            //var admVM = new AdmisionCreateViewModel();
            //foreach (var item in ate.Admision)
            //{
            //    adm = item;
            //}
            //foreach (var item in ate.Interconsulta)
            //{
            //    inter.Add(item);
            //}

            //admVM.AtenId = ate.Id;
            //admVM.Id = adm.Id;

            //admVM.DocIde = ate.DocIde;
            //admVM.NomApe = ate.NomApe;
            //admVM.Empres = ate.Empres;
            //admVM.HorIng = adm.HorIng;
            //admVM.HorSal = adm.HorSal;
            //admVM.Pendie = adm.Pendie;
            //admVM.interconsultas = inter;

            //if (admVM == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(admVM);
        }

        // GET: Admisions/Create
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
        public ActionResult Create( AdmisionCreateViewModel admisionVM)
        {
            
                var adm = new Admision();
                adm.AtenId = admisionVM.AtenId;
                adm.HorIng = admisionVM.HorIng;
                adm.HorSal = admisionVM.HorSal;
                adm.Pendie = admisionVM.Pendie;
                adm.Usuari = "lorem";
                adm.UserName = HttpContext.User.Identity.Name;
                db.Admision.Add(adm);
                db.SaveChanges();
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

        // GET: Admisions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admision admision = db.Admision.Find(id);
            if (admision == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtenId = new SelectList(db.Atenciones, "Id", "Local0", admision.AtenId);
            return View(admision);
        }

        // POST: Admisions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AtenId,HorIng,HorSal,Usuari,Pendie,UserName")] Admision admision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtenId = new SelectList(db.Atenciones, "Id", "Local0", admision.AtenId);
            return View(admision);
        }

        // GET: Admisions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admision admision = db.Admision.Find(id);
            if (admision == null)
            {
                return HttpNotFound();
            }
            return View(admision);
        }

        // POST: Admisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admision admision = db.Admision.Find(id);
            db.Admision.Remove(admision);
            db.SaveChanges();
            return RedirectToAction("Index");
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
