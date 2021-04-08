using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SG_ASP_1.Models;
using System.Text;

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


        public ActionResult Medicina( int Id) 
        {
            if (!db.Medicina.Any(e => e.AtenId == Id))
            {
                return RedirectToAction("MedicinaCreate", "Medicina", new { Id });
            }
            else
            {
                return RedirectToAction("MedicinaDetails", "Medicina", new { Id });
            }
        }

        public ActionResult Auditoria( int Id) 
        {
            if (!db.Auditoria.Any(e=> e.AtenId == Id))
            {
                return RedirectToAction("Create", "Auditorias", new { Id });
            }
            else
            {
                return RedirectToAction("Details", "Auditorias", new { Id });
            }
        }

        public ActionResult Admision(int Id)
        {
            if (!db.Admision.Any(e => e.AtenId == Id))
            {
                return RedirectToAction("Create", "Admisions", new { Id });
            }
            else
            {
                return RedirectToAction("Details", "Admisions", new { Id });
            }
        }

        public ActionResult Enfermeria(int Id)
        {
            if (!db.Interconsulta.Any(e => e.AtenId == Id))
            {
                return RedirectToAction("Details", "EnfermeriaViewModels", new { Id });
            }
            else
            {
                return RedirectToAction("Create", "EnfermeriaViewModels", new { Id });
            }
        }

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
            List<string> estado = new List<string>();
            estado.Add("");
            ViewBag.Estado = estado;
            return View();
        }

        // POST: Atenciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file)
        {
            if (file!=null)
            {
                try
                {
                    List<string> estado = new List<string>();
                    estado.Add("Iniciando Importacion de datos");
                    int n = 0;
                    Stream st = file.InputStream;
                    var reader = new StreamReader(st, Encoding.UTF8);

                    while (reader.Peek() >= 0)
                    {
                        var ate = new Atenciones();
                        string[] LineaReg = reader.ReadLine().Split('\t');
                        ate.Id = int.Parse(LineaReg[0].ToString());
                        ate.Local0 = LineaReg[1].ToString();
                        ate.TipExa = LineaReg[2].ToString();
                        ate.FecAte = DateTime.Parse(LineaReg[3].ToString());
                        ate.NomApe = LineaReg[4].ToString();
                        ate.DocIde = LineaReg[5].ToString();
                        ate.Empres = LineaReg[6].ToString();
                        ate.SubCon = LineaReg[7].ToString();
                        ate.Proyec = LineaReg[8].ToString();
                        ate.Perfil = LineaReg[9].ToString();
                        ate.Area = LineaReg[10].ToString();
                        ate.PueTra = LineaReg[11].ToString();
                        ate.PeReAd = LineaReg[12].ToString();
                        ate.Hora = TimeSpan.Parse(LineaReg[13].ToString());
                        if (LineaReg[14].ToString()=="")
                        {
                            ate.Medico = null;
                        }
                        else
                        {
                            ate.Medico = LineaReg[14].ToString();
                        }

                        if (!db.Atenciones.Any(c=> c.Id==ate.Id))
                        {
                            db.Atenciones.Add(ate);
                            db.SaveChanges();

                            n++;
                            estado.Add("Registros incertados [ID]= " + ate.Id);
                        }
                        else
                        {
                            n++;
                            estado.Add("-------------------Registro no insertado por que ID ya existe [ID]= " + ate.Id );
                        }

                        ViewBag.Estado = estado;
                    }

                    ViewBag.Confirmacion = "Se Importaron " + n + "Registros";
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error de importacion: " + ex.Message;
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "No se seleccionó ningun archivo";
                return View();
            }
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
