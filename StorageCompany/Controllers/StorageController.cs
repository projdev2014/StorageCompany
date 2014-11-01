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
    public class StorageController : Controller
    {
        private StorageEntityDataModel db = new StorageEntityDataModel();

        // GET: /Storage/
        public ActionResult Index()
        {
            var storage = db.Storage.Include(s => s.Storage2).Include(s => s.StorageType);
            return View(storage.ToList());
        }

        // GET: /Storage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Storage storage = db.Storage.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        // GET: /Storage/Create
        public ActionResult Create()
        {
            ViewBag.storageParentId = new SelectList(db.Storage, "id", "name");
            ViewBag.storageTypeId = new SelectList(db.StorageType, "id", "name");
            return View();
        }

        // POST: /Storage/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,storageTypeId,storageParentId,name,usable")] Storage storage)
        {
            if (ModelState.IsValid)
            {
                db.Storage.Add(storage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.storageParentId = new SelectList(db.Storage, "id", "name", storage.storageParentId);
            ViewBag.storageTypeId = new SelectList(db.StorageType, "id", "name", storage.storageTypeId);
            return View(storage);
        }

        // GET: /Storage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Storage storage = db.Storage.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            ViewBag.storageParentId = new SelectList(db.Storage, "id", "name", storage.storageParentId);
            ViewBag.storageTypeId = new SelectList(db.StorageType, "id", "name", storage.storageTypeId);
            return View(storage);
        }

        // POST: /Storage/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,storageTypeId,storageParentId,name,usable")] Storage storage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.storageParentId = new SelectList(db.Storage, "id", "name", storage.storageParentId);
            ViewBag.storageTypeId = new SelectList(db.StorageType, "id", "name", storage.storageTypeId);
            return View(storage);
        }

        // GET: /Storage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Storage storage = db.Storage.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        // POST: /Storage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Storage storage = db.Storage.Find(id);
            db.Storage.Remove(storage);
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
