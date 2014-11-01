using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StorageCompany.Models;

namespace StorageCompany.Controllers
{
    public class StorageTypeController : Controller
    {
        private StorageEntityDataModel db = new StorageEntityDataModel();

        // GET: /StorageType/
        public ActionResult Index()
        {
            return View(db.StorageType.ToList());
        }

        // GET: /StorageType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageType storagetype = db.StorageType.Find(id);
            if (storagetype == null)
            {
                return HttpNotFound();
            }
            return View(storagetype);
        }

        // GET: /StorageType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /StorageType/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,description,maxWidth,maxLength,maxHeight,maxWeight")] StorageType storagetype)
        {
            if (ModelState.IsValid)
            {
                db.StorageType.Add(storagetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storagetype);
        }

        // GET: /StorageType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageType storagetype = db.StorageType.Find(id);
            if (storagetype == null)
            {
                return HttpNotFound();
            }
            return View(storagetype);
        }

        // POST: /StorageType/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,description,maxWidth,maxLength,maxHeight,maxWeight")] StorageType storagetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storagetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storagetype);
        }

        // GET: /StorageType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageType storagetype = db.StorageType.Find(id);
            if (storagetype == null)
            {
                return HttpNotFound();
            }
            return View(storagetype);
        }

        // POST: /StorageType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StorageType storagetype = db.StorageType.Find(id);
            db.StorageType.Remove(storagetype);
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
