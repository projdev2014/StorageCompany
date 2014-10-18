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
                    FormsAuthentication.SetAuthCookie(user.firstname + " " + user.name, false);
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }

            }
            return View();
        }

        public ActionResult Logout()
        {
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