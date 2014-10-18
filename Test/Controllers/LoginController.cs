using StorageCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace StorageCompany.Controllers
{
    public class LoginController : Controller
    {
        private StorageEntityDataModel db = new StorageEntityDataModel();

        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if(ModelState.IsValid)
            {
                if(user.username == "user" && user.password == "test1234") // Simulate data store
                {
                    FormsAuthentication.SetAuthCookie(user.username, false);
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }

            }
            return View("Login");
        }

        [HttpGet]
        public ActionResult Registration()
        {

            ViewBag.roleId = new SelectList(db.Role, "id", "name");
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StorageEntityDataModel())
                {
                    var sysUser = db.User.Create();
                    sysUser.password = GetMD5HashData(user.password);
                    sysUser.name = user.name;
                    sysUser.firstname = user.firstname;
                    sysUser.roleId = user.roleId;

                    db.User.Add(user);
                    db.SaveChanges();   
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

        private bool isValid(string username, string password)
        {
            bool isValid = false;

            using (var db = new StorageEntityDataModel())
            {
                var user = db.User.FirstOrDefault(u => u.username == username);
                if (user != null)
                {
                    if (user.password == GetMD5HashData(password))
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

        private string GetMD5HashData(string data)
        {
            //create new instance of md5
            MD5 md5 = MD5.Create();

            //convert the input text to array of bytes
            byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();
        }

        private bool ValidateMD5HashData(string inputData, string storedHashData)
        {
            //hash input text and save it string variable
            string getHashInputData = GetMD5HashData(inputData);

            if (string.Compare(getHashInputData, storedHashData) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
	}
}