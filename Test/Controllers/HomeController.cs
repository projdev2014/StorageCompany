using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StorageCompany.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Home";
            return View("Index");
        }

        //
        // GET: /Order/
        public ActionResult Order()
        {
            ViewBag.Message = "Order";
            return View("Order");
        }

        //
        // GET: /Inventory/
        public ActionResult Inventory()
        {
            ViewBag.Message = "Inventory";
            return View("Inventory");
        }

    }
}