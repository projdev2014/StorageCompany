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
    public class TestMovementController : Controller
    {
        private StorageEntityDataModel db = new StorageEntityDataModel();

        // GET: /TestMovement/
        public ActionResult Index()
        {
            var movement = db.Movement.Include(m => m.Item).Include(m => m.Order).Include(m => m.Status).Include(m => m.Storage);
            return View(movement.ToList());
        }

        // GET: /TestMovement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movement movement = db.Movement.Find(id);
            if (movement == null)
            {
                return HttpNotFound();
            }
            return View(movement);
        }

        // GET: /TestMovement/Create
        public ActionResult Create()
        {
            ViewBag.itemId = new SelectList(db.Item, "id", "id");
            ViewBag.orderId = new SelectList(db.Order, "id", "id");
            ViewBag.statusId = new SelectList(db.Status, "id", "name");
            ViewBag.storageId = new SelectList(db.Storage, "id", "name");
            return View();
        }

        // POST: /TestMovement/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,statusId,orderId,itemId,storageId,dateDone")] Movement movement)
        {
            if (ModelState.IsValid)
            {
                db.Movement.Add(movement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.itemId = new SelectList(db.Item, "id", "id", movement.itemId);
            ViewBag.orderId = new SelectList(db.Order, "id", "id", movement.orderId);
            ViewBag.statusId = new SelectList(db.Status, "id", "name", movement.statusId);
            ViewBag.storageId = new SelectList(db.Storage, "id", "name", movement.storageId);
            return View(movement);
        }

        // GET: /TestMovement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movement movement = db.Movement.Find(id);
            if (movement == null)
            {
                return HttpNotFound();
            }
            ViewBag.itemId = new SelectList(db.Item, "id", "id", movement.itemId);
            ViewBag.orderId = new SelectList(db.Order, "id", "id", movement.orderId);
            ViewBag.statusId = new SelectList(db.Status, "id", "name", movement.statusId);
            ViewBag.storageId = new SelectList(db.Storage, "id", "name", movement.storageId);
            return View(movement);
        }

        // POST: /TestMovement/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,statusId,orderId,itemId,storageId,dateDone")] Movement movement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.itemId = new SelectList(db.Item, "id", "id", movement.itemId);
            ViewBag.orderId = new SelectList(db.Order, "id", "id", movement.orderId);
            ViewBag.statusId = new SelectList(db.Status, "id", "name", movement.statusId);
            ViewBag.storageId = new SelectList(db.Storage, "id", "name", movement.storageId);
            return View(movement);
        }

        // GET: /TestMovement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movement movement = db.Movement.Find(id);
            if (movement == null)
            {
                return HttpNotFound();
            }
            return View(movement);
        }

        // POST: /TestMovement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movement movement = db.Movement.Find(id);
            db.Movement.Remove(movement);
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
