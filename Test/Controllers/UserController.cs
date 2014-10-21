using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StorageCompany.Models;
using System.Security.Cryptography;
using System.Text;
using StorageCompany.Security;

namespace StorageCompany.Controllers
{
    public class UserController : Controller
    {
        private Encryption encryption = new Encryption();
        private StorageEntityDataModel db = new StorageEntityDataModel();

        // GET: /User/
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var user = db.User.Include(u => u.Role);
            return View(user.ToList());
        }

        // GET: /User/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /User/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.roleId = new SelectList(db.Role, "id", "name");
            return View();
        }

        // POST: /User/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include="id,firstname,name,username,password,roleId")] User user)
        {
            if (ModelState.IsValid)
            {
                user.password = encryption.GetMD5HashData(user.password);
                db.User.Add(user);            
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.roleId = new SelectList(db.Role, "id", "name", user.roleId);
            return View(user);
        }

        // GET: /User/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.roleId = new SelectList(db.Role, "id", "name", user.roleId);
            return View(user);
        }

        // POST: /User/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include="id,firstname,name,username,password,roleId")] User user)
        {
            if (ModelState.IsValid)
            {
                user.password = encryption.GetMD5HashData(user.password);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.roleId = new SelectList(db.Role, "id", "name", user.roleId);
            return View(user);
        }

        // GET: /User/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
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
