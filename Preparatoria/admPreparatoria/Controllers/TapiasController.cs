using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admPreparatoria.Models;

namespace admPreparatoria.Controllers
{
    public class TapiasController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Tapias
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Tapias.ToList());
        }

        // GET: Tapias/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tapia tapia = db.Tapias.Find(id);
            if (tapia == null)
            {
                return HttpNotFound();
            }
            return View(tapia);
        }

        // GET: Tapias/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tapias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TapiaID,FriendofTapia,place,Email,Birthdate")] Tapia tapia)
        {
            if (ModelState.IsValid)
            {
                db.Tapias.Add(tapia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tapia);
        }

        // GET: Tapias/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tapia tapia = db.Tapias.Find(id);
            if (tapia == null)
            {
                return HttpNotFound();
            }
            return View(tapia);
        }

        // POST: Tapias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TapiaID,FriendofTapia,place,Email,Birthdate")] Tapia tapia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tapia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tapia);
        }

        // GET: Tapias/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tapia tapia = db.Tapias.Find(id);
            if (tapia == null)
            {
                return HttpNotFound();
            }
            return View(tapia);
        }

        // POST: Tapias/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tapia tapia = db.Tapias.Find(id);
            db.Tapias.Remove(tapia);
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
