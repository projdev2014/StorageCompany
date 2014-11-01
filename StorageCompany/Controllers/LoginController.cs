using StorageCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.Data.Entity;
using StorageCompany.Security;

namespace StorageCompany.Controllers
{
    public class LoginController : Controller
    {
        private StorageEntityDataModel db = new StorageEntityDataModel();
        private Encryption encryption = new Encryption();

        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if (user.username != "" && user.password != "")
            {
                if (isValid(user.username, user.password))
                {
                    user = db.User.FirstOrDefault(u => u.username == user.username);
                    Session["name"] = user.name;
                    Session["firstname"] = user.firstname;
                    Session["role"] = user.Role.name;
                    Session["username"] = user.username;
                    FormsAuthentication.SetAuthCookie(user.username, false);
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ManageUserViewModel model)
        {  
            if (ModelState.IsValid)
            {
                String username = (String) Session["username"];
                User user =  db.User.FirstOrDefault(u => u.username == username);
                if(user != null && user.password == encryption.GetMD5HashData(model.OldPassword))
                {
                    user.password = encryption.GetMD5HashData(model.NewPassword);
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The old username is incorect");
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "Home");
        }

        private bool isValid(string username, string password)
        {
            bool isValid = false;

            using (var db = new StorageEntityDataModel())
            {
                var user = db.User.FirstOrDefault(u => u.username == username);
                if (user != null)
                {
                    if (user.password == encryption.GetMD5HashData(password))
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

       

        
	}
}