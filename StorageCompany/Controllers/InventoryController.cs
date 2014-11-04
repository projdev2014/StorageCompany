using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StorageCompany.Models.StoredProcedure;
using StorageCompany.DataAccessLayer;
using StorageCompany.Models;

namespace StorageCompany.Controllers
{
    public class InventoryController : Controller
    {
        private DataAccessObject dbo = new DataAccessObject();
        private StorageEntityDataModel db = new StorageEntityDataModel();

        
        // GET: /Inventory/OrderList
        public ActionResult OrderList()
        {
            var sp_order = dbo.getListOrder();
            return View(sp_order);
        }

        
        // GET: /Inventory/MovementList
        public ActionResult MovementList()
        {
            var sp_movement = dbo.getListMovement();
            return View(sp_movement);
        }

        
        // GET: /Inventory/ItemList
        public ActionResult StorageList()
        {
            return View(db.Storage.OrderBy(a => a.storageParentId).ToList());
        }

        public ActionResult Test()
        {
            return View();
        }

	}
}