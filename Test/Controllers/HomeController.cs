using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StorageCompany.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Message = Ressources.StringsDispalyed.title_home;
            return View("Index");
        }

        //
        // GET: /Order/
        public ActionResult Order()
        {
            ViewBag.Message = Ressources.StringsDispalyed.title_order;
            return View("Order");
        }

        //
        // GET: /Inventory/
        public ActionResult Inventory()
        {
            ViewBag.Message = Ressources.StringsDispalyed.title_inventory;
            return View("Inventory");
        }

    }
}