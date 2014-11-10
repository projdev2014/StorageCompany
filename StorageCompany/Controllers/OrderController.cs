using StorageCompany.DataAccessLayer;
using StorageCompany.Models;
using StorageCompany.Models.StoredProcedure;
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
            List<ItemIn> listItemIn = (List<ItemIn>)Session["listItemIn"];
            if (listItemIn == null)
            {
                listItemIn = new List<ItemIn>();
            }
            foreach (ItemIn item in listItemIn)
            {
                item.Product = db.Product.Find(item.productId);
                item.Storage = db.Storage.Find(item.storageId);
            }
            return View(listItemIn);
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

        public ActionResult Step3_MovementIn()
        {
            List<ItemIn> listItemIn = (List<ItemIn>)Session["listItemIn"];
            if (listItemIn != null)
            {
                return View();
            }
            return RedirectToAction("Step2_MovementIn");
        }

        // GET: /Order/CreateItemIn
        public ActionResult CreateItemIn()
        {
            var model = new ItemIn();
            Order order = (Order)Session["order"];
            List<ItemIn> list = (List<ItemIn>)Session["listItemIn"];
            List<Storage> listStorage = new List<Storage>();
            listStorage = dbo.getListEmptyStorage(order.dateEstimated);
            listStorage = dbo.subList(listStorage, list);
            ViewBag.storageId = new SelectList(listStorage, "id", "name");
            ViewBag.productId = new SelectList(db.Product, "id", "name");

            return PartialView();
        }

        // POST: /Order/CreateItemIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItemIn([Bind(Include="id,timeExpire,productId,storageId")] ItemIn item)
        {
            if (ModelState.IsValid)
            {
                List<ItemIn> listItemIn = (List<ItemIn>) Session["listItemIn"];
                if (listItemIn == null)
                {
                    listItemIn = new List<ItemIn>();
                }
                listItemIn.Add(item);
                Session["listItemIn"] = listItemIn;
                return RedirectToAction("Step2_MovementIn");
            }
            Order order = (Order)Session["order"];
            List<ItemIn> list = (List<ItemIn>)Session["listItemIn"];
            List<Storage> listStorage = dbo.getListEmptyStorage(order.dateEstimated);
            listStorage = dbo.subList(listStorage, list);
            ViewBag.storageId = new SelectList(listStorage, "id", "name", item.storageId);
            ViewBag.productId = new SelectList(db.Product, "id", "name", item.productId);
            return View(item);
        }

         public ActionResult DeleteItemIn(int id)
        {
            List<ItemIn> listItemIn = (List<ItemIn>)Session["listItemIn"];
            List<ItemIn> newListItemIn = new List<ItemIn>(listItemIn);
            foreach (ItemIn item in listItemIn)
            {
                if (item.storageId == id)
                {
                    newListItemIn.Remove(item);
                }
            }
            Session["listItemIn"] = newListItemIn;
            return RedirectToAction("Step2_MovementIn");
        }

        public ActionResult createMovementIn(){
            Order o = (Order) Session["Order"];

            // Enregistrement et récupération de l'id
            using (var context = new StorageEntityDataModel())
            {
                var order = new Order();
                order.accountRecipientId = o.accountRecipientId;
                order.accountSenderId = o.accountSenderId;
                order.dateEstimated = o.dateEstimated;
                order.dateAsked = DateTime.Now;
                order.intern = false;
                context.Order.Attach(order);
                context.Order.Add(order);
                context.SaveChanges();
                // récupération de l'id
                o.id = order.id;
            }
            
            
            List<ItemIn> listItemIn = (List<ItemIn>)Session["listItemIn"];
            List<ItemIn> newListItemIn = new List<ItemIn>(listItemIn);
            // Createion des items + mouvements pour chaque item de la listItemIn
            foreach (ItemIn item in listItemIn)
            {
                // Création de l'item
                Item i = new Item();
                i.timeExpire = item.timeExpire;
                i.productId = item.productId;
                // Sauvegarde de l'item dans la db
                db.Item.Add(i);
                db.SaveChanges();
                
                // Création du mouvement
                Movement m = new Movement();
                m.dateDone = o.dateEstimated;
                m.itemId = i.id;
                m.orderId = o.id;
                m.statusId = 1; // A sa création le mouvement a le statut "à faire";
                m.storageId = item.storageId;
                
                // Sauvegarde du mouvement dans la db
                db.Movement.Add(m);
                db.SaveChanges();

            }
            Session["order"] = null;
            Session["listItemIn"] = null;
            return RedirectToAction("Step1_Order");
        }

        public ActionResult annuleMovementIn(){
            Session["order"] = null;
            Session["listItemIn"] = null;
            return RedirectToAction("Step1_Order");
        }

	}
}