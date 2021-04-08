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

        // GET: EnfermeriaViewModels
       
        // GET: EnfermeriaViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnfermeriaViewModel enfermeriaViewModel = db.EnfermeriaViewModels.Find(id);
            if (enfermeriaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(enfermeriaViewModel);
        }

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

        // POST: EnfermeriaViewModels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomApe,DocIde,Empres,AtenId")] EnfermeriaViewModel enfermeriaViewModel)
        {
            if (ModelState.IsValid)
            {
                db.EnfermeriaViewModels.Add(enfermeriaViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enfermeriaViewModel);
        }

        // GET: EnfermeriaViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnfermeriaViewModel enfermeriaViewModel = db.EnfermeriaViewModels.Find(id);
            if (enfermeriaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(enfermeriaViewModel);
        }

        // POST: EnfermeriaViewModels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomApe,DocIde,Empres,AtenId")] EnfermeriaViewModel enfermeriaViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enfermeriaViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enfermeriaViewModel);
        }

        // GET: EnfermeriaViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnfermeriaViewModel enfermeriaViewModel = db.EnfermeriaViewModels.Find(id);
            if (enfermeriaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(enfermeriaViewModel);
        }

        // POST: EnfermeriaViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnfermeriaViewModel enfermeriaViewModel = db.EnfermeriaViewModels.Find(id);
            db.EnfermeriaViewModels.Remove(enfermeriaViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
