using StorageCompany.DataAccessLayer;
using StorageCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StorageCompany.Controllers
{
    public class OrderController : Controller
    {
        private StorageEntityDataModel db = new StorageEntityDataModel();
        private DataAccessObject dbo = new DataAccessObject();
        //
        // GET: /Order/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Step1_Order()
        {
            ViewBag.accountRecipientId = new SelectList(db.Account, "id", "name");
            ViewBag.accountSenderId = new SelectList(db.Account, "id", "name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Step1_Order([Bind(Include = "id,accountSenderId,accountRecipientId,dateAsked,dateEstimated,dateDone,intern")] Order order)
        {
            if (ModelState.IsValid)
            {
                Account recipient = db.Account.Find(order.accountRecipientId);
                Account sender = db.Account.Find(order.accountSenderId);

                if (sender.intern == true && recipient.intern == true) // if sender and recipient are intern
                {
                    order.intern = true;
                    Session["order"] = order;
                    return RedirectToAction("Step2_MovementInternal"); 
                }
                else if (sender.intern == true) // if sender is intern
                {
                    order.intern = false;
                    Session["order"] = order;
                    return RedirectToAction("Step2_MovementOut");
                }
                else if (recipient.intern == true) // if recipient is intern
                {
                    order.intern = false;
                    Session["order"] = order;
                    return RedirectToAction("Step2_MovementIn");
                }
                else // if sender and recipient are extern
                {
                    ModelState.AddModelError("accountSenderId", "L'expéditeur et le destintaire ne peuvent être externes tous les deux");
                    ModelState.AddModelError("accountRecipientId", "L'expéditeur et le destintaire ne peuvent être externes tous les deux");   
                }
            }
            ViewBag.accountRecipientId = new SelectList(db.Account, "id", "name");
            ViewBag.accountSenderId = new SelectList(db.Account, "id", "name");
            return View(order);
        }

        public ActionResult Step2_MovementIn()
        {
            Order order = (Order) Session["order"];
            ViewBag.storageId = new SelectList(dbo.getListEmptyStorage(order.dateEstimated), "id", "name");
            ViewBag.productId = new SelectList(db.Product, "id", "name");
            return View("Step2_MovementIn");
        }

        public ActionResult Step2_MovementOut()
        {
            ViewBag.itemId = new SelectList(db.Item, "id", "id");
            ViewBag.orderId = new SelectList(db.Order, "id", "id");
            ViewBag.statusId = new SelectList(db.Status, "id", "name");
            ViewBag.storageId = new SelectList(db.Storage, "id", "name");
            return View("Step2_MovementOut");
        }

        public ActionResult Step2_MovementInternal()
        {
            ViewBag.itemId = new SelectList(db.Item, "id", "id");
            ViewBag.orderId = new SelectList(db.Order, "id", "id");
            ViewBag.statusId = new SelectList(db.Status, "id", "name");
            ViewBag.storageId = new SelectList(db.Storage, "id", "name");
            return View("Step2_MovementInternal");
        }

        public ActionResult Step3_Confirmation()
        {
            return View("Step3_Confirmation");
        }
	}
}