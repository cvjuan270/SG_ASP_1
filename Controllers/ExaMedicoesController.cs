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
    public class ExaMedicoesController : Controller
    {
        private SG_ASP_1Context db = new SG_ASP_1Context();

        // GET: ExaMedicoes
        public ActionResult Index()
        {
            return View(db.ExaMedicoes.ToList());
        }


        // GET: ExaMedicoes/Create
        [Authorize(Roles = "Auditoria,Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExaMedicoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Auditoria,Admin")]
        public ActionResult Create([Bind(Include = "Id,Examen")] ExaMedico exaMedico)
        {
            if (ModelState.IsValid)
            {
                db.ExaMedicoes.Add(exaMedico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exaMedico);
        }

        // GET: ExaMedicoes/Edit/5
        [Authorize(Roles = "Auditoria,Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExaMedico exaMedico = db.ExaMedicoes.Find(id);
            if (exaMedico == null)
            {
                return HttpNotFound();
            }
            return View(exaMedico);
        }

        // POST: ExaMedicoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Auditoria,Admin")]
        public ActionResult Edit([Bind(Include = "Id,Examen")] ExaMedico exaMedico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exaMedico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exaMedico);
        }

        // GET: ExaMedicoes/Delete/5
        [Authorize(Roles = "Auditoria,Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExaMedico exaMedico = db.ExaMedicoes.Find(id);
            if (exaMedico == null)
            {
                return HttpNotFound();
            }
            return View(exaMedico);
        }

        // POST: ExaMedicoes/Delete/5
        [Authorize(Roles = "Auditoria,Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExaMedico exaMedico = db.ExaMedicoes.Find(id);
            db.ExaMedicoes.Remove(exaMedico);
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
