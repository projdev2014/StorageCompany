﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StorageCompany.Models.StoredProcedure;
using StorageCompany.DataAccessLayer;
using StorageCompany.Models.StoredProcedure.StorageCompany.DataAccessLayer;

namespace StorageCompany.Controllers
{
    public class InventoryController : Controller
    {
        private DataAccessObject db = new DataAccessObject();

        
        // GET: /Inventory/OrderList
        public ActionResult OrderList()
        {
            var sp_order = db.getListOrder();
            return View(sp_order);
        }

        
        // GET: /Inventory/MovementList
        public ActionResult MovementList()
        {
            return View();
        }

        
        // GET: /Inventory/ItemList
        public ActionResult ItemList()
        {
            return View();
        }

	}
}