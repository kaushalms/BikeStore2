using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeStore.Models;

namespace BikeStore.Controllers
{
    [Authorize(Roles = "Employee")]
    public class OrderSummaryController : Controller
    {
        private BikeStoreEntities db = new BikeStoreEntities();

        // GET: OrderSummary
        public ActionResult Index()
        {
            int userid = Convert.ToInt32(Session["LogedUserID"]);
            Employee store_obj=db.Employees.Where(e=>e.EmployeeId==userid).SingleOrDefault();

            var orderdetail = db.OrderDetails.Include(o => o.Inventory).Include(o => o.Order.OrderStage).Include(o => o.Order).Where(e => e.StoreId == store_obj.StoreId);
            return View(orderdetail.ToList());
        }

        // GET: OrderSummary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //// GET: OrderSummary/Create
        //public ActionResult Create()
        //{
        //    ViewBag.PayModeId = new SelectList(db.PayModes, "PayModeId", "PayMethod");
        //    return View();
        //}

        //// POST: OrderSummary/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "OrderId,FirstName,LastName,OrderDate,PickUpDate,PayModeId,Total")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Orders.Add(order);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.PayModeId = new SelectList(db.PayModes, "PayModeId", "PayMethod", order.PayModeId);
        //    return View(order);
        //}

        // GET: OrderSummary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.PayModeId = new SelectList(db.PayModes, "PayModeId", "PayMethod", order.PayModeId);
            ViewBag.OrderStatusId = new SelectList(db.OrderStatuss, "OrderStatusId", "OrderStatusName", order.OrderStatusId);
            ViewBag.OrderStageId = new SelectList(db.OrderStages, "OrderStageId", "OrderStageName", order.OrderStageId);
            return View(order);
        }

        // POST: OrderSummary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,FirstName,LastName,OrderDate,PickUpDate,PayModeId,Total,OrderStatusId,OrderStageId")] Order order)
        {
            if (ModelState.IsValid)
            {
                OrderStatus orderstatus_obj=db.OrderStatuss.Where(o=>o.OrderStatusName=="Online").SingleOrDefault();
                if (order.OrderStatusId == orderstatus_obj.OrderStatusId)
                { order.Bonus = 5; }
                else 
                { order.Bonus = 50; }
                order.EmployeeId = Convert.ToInt32(Session["LogedUserID"]);

                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PayModeId = new SelectList(db.PayModes, "PayModeId", "PayMethod", order.PayModeId);
            ViewBag.OrderStatusId = new SelectList(db.OrderStatuss, "OrderStatusId", "OrderStatusName", order.OrderStatusId);
            ViewBag.OrderStageId = new SelectList(db.OrderStages, "OrderStageId", "OrderStageName", order.OrderStatusId);
            return View(order);
        }

        // GET: OrderSummary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: OrderSummary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
