using SG_ASP_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SG_ASP_1.Controllers
{
    public class MedicinaController : Controller
    {
        private SG_ASP_1Context db = new SG_ASP_1Context();
        // GET: Medicina
        public ActionResult MedicinaCreate (int Id=2)
        {
            var aten = db.Atenciones.Find(Id);
            var Medi = new MedicinaCreateViewModel();
            Medi.AtenId = aten.Id;
            Medi.oAteId = aten.Id;
            Medi.TipExa = aten.TipExa;
            Medi.NomApe = aten.NomApe;
            Medi.DocIde = aten.DocIde;
            Medi.Empres = aten.Empres;
            //ViewBag.Medico = new SelectList(db.Medicos, "Medico", "Medico", atenciones.Medico);
            ViewBag.Medico = new SelectList(db.Medicos, "Medico", "Medico", Medi.Medico);
            return View(Medi);
        }

        [HttpPost]
        public ActionResult MedicinaCreate(MedicinaCreateViewModel model) 
        {
            if (ModelState.IsValid)
            {
                Medicina med = new Medicina();
                med.AtenId = model.oAteId;
                med.HorIng = model.HorIng;
                med.HorSal = model.HorSal;
                med.Medico = model.Medico;
                med.Aptitu = model.Aptitu;
                med.FecApt = model.FecApt;
                med.FecEnv = model.FecEnv;
                med.Observ = model.Observ;
                med.Coment = model.Coment;

                db.Medicina.Add(med);
                db.SaveChanges();

                foreach (var item in model.interconsultas)
                {
                    var inte = new Interconsulta();
                    inte.AtenId = model.AtenId;
                    inte.IntCon = item.IntCon;
                }

                return RedirectToAction("Index", "Atenciones");

            }
            return View(model);
        }


        protected override void Dispose(bool disposing)
        {
            if (true)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}