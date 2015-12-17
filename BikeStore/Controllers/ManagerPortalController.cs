using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BikeStore.Controllers
{
    [Authorize(Roles="Manager")]
    public class ManagerPortalController : Controller
    {
        private BikeStoreEntities db = new BikeStoreEntities();


        public ActionResult Index()
        {
            var stores = db.Stores.ToList();
            return View(stores);
        }


        // GET: ManagerPortal
        public ActionResult ShowAllData(int store)
        {
            DateTime dt = Convert.ToDateTime(DateTime.Now.AddDays(-7));
            //DateTime today = dt.Date;
            DateTime startDateTime = DateTime.Today; //Today at 00:00:00
            DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1); //Today at 23:59:59
            ViewBag.order_sum_current_day = db.OrderDetails.Include(i => i.Inventory).Include(o => o.Order.OrderStage).Include(o => o.Order).Where(s => s.StoreId == store && s.Order.OrderStage.OrderStageName == "Confirm" && s.Order.OrderDate >= startDateTime && s.Order.OrderDate <= endDateTime).Sum(p => (decimal?)p.Order.Total) ?? 0;
            ViewBag.order_sum_current_week = db.OrderDetails.Include(i => i.Inventory).Include(o => o.Order.OrderStage).Include(o => o.Order).Where(s => s.StoreId == store && s.Order.OrderStage.OrderStageName == "Confirm" && s.Order.OrderDate > dt).Sum(p => (decimal?)p.Order.Total) ?? 0;
            ////ViewBag.order_sum = db.OrderDetails.Include(i => i.Inventory).Include(o => o.Order.OrderStage).Include(o => o.Order).Where(s => s.StoreId == store && s.Order.OrderStage.OrderStageName == "Confirm").Sum(p => p.Order.Total);
            ViewBag.order_Bonus_current_day = db.OrderDetails.Include(i => i.Inventory).Include(o => o.Order.OrderStage).Include(o => o.Order).Where(s => s.StoreId == store && s.Order.OrderStage.OrderStageName == "Confirm" && s.Order.OrderDate >= startDateTime && s.Order.OrderDate <= endDateTime).Sum(p => (decimal?)p.Order.Bonus) ?? 0;
            ViewBag.order_Bonus_current_week = db.OrderDetails.Include(i => i.Inventory).Include(o => o.Order.OrderStage).Include(o => o.Order).Where(s => s.StoreId == store && s.Order.OrderStage.OrderStageName == "Confirm" && s.Order.OrderDate > dt).Sum(p => (decimal?)p.Order.Bonus) ?? 0;
            decimal inventory_cost_day = db.OrderDetails.Include(i => i.Inventory).Include(o => o.Order.OrderStage).Include(o => o.Order).Where(s => s.StoreId == store && s.Order.OrderStage.OrderStageName == "Confirm" && s.Order.OrderDate >= startDateTime && s.Order.OrderDate <= endDateTime).Sum(p => (decimal?)p.Inventory.UnitPrice) ?? 0;
            decimal inventory_cost_week = db.OrderDetails.Include(i => i.Inventory).Include(o => o.Order.OrderStage).Include(o => o.Order).Where(s => s.StoreId == store && s.Order.OrderStage.OrderStageName == "Confirm" && s.Order.OrderDate > dt).Sum(p => (decimal?)p.Inventory.UnitPrice) ?? 0;
            ////ViewBag.Inventory_Cost_Day = inventory_cost;
            decimal selling_cost_day = db.OrderDetails.Include(i => i.Inventory).Include(o => o.Order.OrderStage).Include(o => o.Order).Where(s => s.StoreId == store && s.Order.OrderStage.OrderStageName == "Confirm" && s.Order.OrderDate >= startDateTime && s.Order.OrderDate <= endDateTime).Sum(p => (decimal?)p.Inventory.SellingPrice) ?? 0;
            decimal selling_cost_week = db.OrderDetails.Include(i => i.Inventory).Include(o => o.Order.OrderStage).Include(o => o.Order).Where(s => s.StoreId == store && s.Order.OrderStage.OrderStageName == "Confirm" && s.Order.OrderDate > dt).Sum(p => (decimal?)p.Inventory.SellingPrice) ?? 0;
            ////ViewBag.Selling_Cost_Day = selling_cost;
            ViewBag.Profit_Current_Day = selling_cost_day - inventory_cost_day;
            ViewBag.Profit_Current_week = selling_cost_week - inventory_cost_week;
            ////ViewBag.Total_Employee = db.Employees.Count(s => s.StoreId == store&&);
            return View();
        }
    }
}