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
    public class InventoryManagerController : Controller
    {
        private BikeStoreEntities db = new BikeStoreEntities();

        // GET: InventoryManager
        
        public ActionResult Index()
        {
            if ((Convert.ToString(Session["LoggedRole"])) == "Employee")
            {
                int userid = Convert.ToInt32(Session["LogedUserID"]);
                Employee store_obj = db.Employees.Where(e => e.EmployeeId == userid).SingleOrDefault();
                var inventories = db.Inventories.Include(i => i.Frame).Include(i => i.Store).Include(i => i.Type).Include(p => p.ProdStatus).Where(i => i.StoreId == store_obj.StoreId);
                return View(inventories.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: InventoryManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: InventoryManager/Create
        public ActionResult Create()
        {
            ViewBag.Frameid = new SelectList(db.Frames, "FrameId", "FrameName");
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName");
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "TypeName");
            ViewBag.ProdStatusId = new SelectList(db.ProdStatuss, "ProdStatusId", "ProdStatusName");
            return View();
        }

        // POST: InventoryManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventoryId,Frameid,TypeId,BrandName,ModelName,Desc,UnitPrice,SellingPrice,StoreId,ProdStatusId")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Frameid = new SelectList(db.Frames, "FrameId", "FrameName", inventory.Frameid);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", inventory.StoreId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "TypeName", inventory.TypeId);
            ViewBag.ProdStatusId = new SelectList(db.ProdStatuss, "ProdStatusId", "ProdStatusName", inventory.ProdStatusId);
            return View(inventory);
        }

        // GET: InventoryManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Frameid = new SelectList(db.Frames, "FrameId", "FrameName", inventory.Frameid);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", inventory.StoreId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "TypeName", inventory.TypeId);
            ViewBag.ProdStatusId = new SelectList(db.ProdStatuss, "ProdStatusId", "ProdStatusName", inventory.ProdStatusId);
            return View(inventory);
        }

        // POST: InventoryManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryId,Frameid,TypeId,BrandName,ModelName,Desc,UnitPrice,SellingPrice,StoreId,ProdStatusId")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Frameid = new SelectList(db.Frames, "FrameId", "FrameName", inventory.Frameid);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", inventory.StoreId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "TypeName", inventory.TypeId);
            ViewBag.ProdStatusId = new SelectList(db.ProdStatuss, "ProdStatusId", "ProdStatusName", inventory.ProdStatusId);
            return View(inventory);
        }

        // GET: InventoryManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: InventoryManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
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
