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
    public class AtencionesController : Controller
    {
        private SG_ASP_1Context db = new SG_ASP_1Context();


        // GET: Atenciones
        public ActionResult Index(DateTime? FecIni, DateTime? FecFin, string BuscarNombre, string Dni, string Empres)
        {
            var atenciones = db.Atenciones.Include(a => a.Medicos);
            atenciones = from cr in db.Atenciones select cr;

            if (String.IsNullOrEmpty(FecIni.ToString()) && String.IsNullOrEmpty(FecFin.ToString()))
            {
                atenciones = atenciones.Where(c => c.FecAte >= DateTime.Now && c.FecAte <= DateTime.Now);
            }

            if (!String.IsNullOrEmpty(FecIni.ToString()) && !String.IsNullOrEmpty(FecFin.ToString()))
            {
                atenciones = atenciones.Where(c => c.FecAte >= FecIni && c.FecAte <= FecFin);
            }

            if (!String.IsNullOrEmpty(BuscarNombre))
            {
                atenciones = atenciones.Where(c => c.NomApe.Contains(BuscarNombre));
            }
            if (!String.IsNullOrEmpty(Dni))
            {
                atenciones = atenciones.Where(c => c.DocIde.Contains(Dni));
            }
            if (!String.IsNullOrEmpty(Empres))
            {
                atenciones = atenciones.Where(c => c.Empres.Contains(Empres));
            }
            return View(atenciones.ToList());
        }
        // GET: Atenciones
        //public ActionResult Index()
        //{
        //    var atenciones = db.Atenciones.Include(a => a.Medicos);
        //    return View(atenciones.ToList());
        //}

        // GET: Atenciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atenciones atenciones = db.Atenciones.Find(id);
            if (atenciones == null)
            {
                return HttpNotFound();
            }
            return View(atenciones);
        }

        // GET: Atenciones/Create
        public ActionResult Create()
        {
            ViewBag.Medico = new SelectList(db.Medicos, "Medico", "Medico");
            return View();
        }

        // POST: Atenciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Local0,TipExa,FecAte,NomApe,DocIde,Empres,SubCon,Proyec,Perfil,Area,PueTra,PeReAd,Hora,Medico")] Atenciones atenciones)
        {
            if (ModelState.IsValid)
            {
                db.Atenciones.Add(atenciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Medico = new SelectList(db.Medicos, "Medico", "Medico", atenciones.Medico);
            return View(atenciones);
        }

        // GET: Atenciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atenciones atenciones = db.Atenciones.Find(id);
            if (atenciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Medico = new SelectList(db.Medicos, "Medico", "Medico", atenciones.Medico);
            return View(atenciones);
        }

        // POST: Atenciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Local0,TipExa,FecAte,NomApe,DocIde,Empres,SubCon,Proyec,Perfil,Area,PueTra,PeReAd,Hora,Medico")] Atenciones atenciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atenciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Medico = new SelectList(db.Medicos, "Medico", "Medico", atenciones.Medico);
            return View(atenciones);
        }

        // GET: Atenciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atenciones atenciones = db.Atenciones.Find(id);
            if (atenciones == null)
            {
                return HttpNotFound();
            }
            return View(atenciones);
        }

        // POST: Atenciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atenciones atenciones = db.Atenciones.Find(id);
            db.Atenciones.Remove(atenciones);
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
