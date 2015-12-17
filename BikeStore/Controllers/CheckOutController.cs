using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeStore.Controllers
{
    public class CheckoutController : Controller
    {
        BikeStoreEntities storeDB = new BikeStoreEntities();

         [Authorize(Roles = "Manager,Employee,Customer")]
        public ActionResult AddressAndPayment()
        {
            ViewBag.PayModeId = new SelectList(storeDB.PayModes, "PayModeId", "PayMethod");
            ViewBag.OrderStatusId = new SelectList(storeDB.OrderStatuss, "OrderStatusId", "OrderStatusName");
            return View();
        }
        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);
           
            try
            {

                order.EmailId = Session["LoggedEmail"].ToString();
                order.OrderDate = DateTime.Now;
                OrderStage orderstage = storeDB.OrderStages.Where(o => o.OrderStageName == "Pending").SingleOrDefault();
                order.OrderStageId = orderstage.OrderStageId;

                //Save Order
                storeDB.Orders.Add(order);
                storeDB.SaveChanges();
                //Process the order
                var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.CreateOrder(order);

                return RedirectToAction("Complete",
                    new { id = order.OrderId });
                
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
          
            
        }
        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            string Email=Convert.ToString(Session["LoggedEmail"]);
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(
                o => o.OrderId == id &&
                o.EmailId == Email);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}