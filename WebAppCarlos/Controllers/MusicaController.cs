using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppCarlos.Models;

namespace WebAppCarlos.Controllers
{
    public class MusicaController : Controller
    {
        private SisMusicaContext db = new SisMusicaContext();


        public ActionResult VerificaTitulo(string Titulo)
        {
            return Json(db.Musicas
                .All(m => m.Titulo.ToLower() != Titulo.ToLower()),
                JsonRequestBehavior.AllowGet);
        }

        // GET: Musica
        public ActionResult Index()
        {
            return View(db.Musicas.ToList());
        }

        // GET: Musica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        // GET: Musica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Categoria,TipoMidea,DateTime")] Musica musica)
        {
            if (ModelState.IsValid)
            {
                db.Musicas.Add(musica);
                db.SaveChanges();
                TempData["Mensagem"] = "Musica cadastrada com sucesso!";
                return RedirectToAction("Index");
            }

            return View(musica);
        }

        // GET: Musica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        // POST: Musica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Categoria,TipoMidea,DateTime")] Musica musica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musica).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensagem"] = "Musica excluida com sucesso!"
                return RedirectToAction("Index");
            }
            return View(musica);
        }

        // GET: Musica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        // POST: Musica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musica musica = db.Musicas.Find(id);
            db.Musicas.Remove(musica);
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
