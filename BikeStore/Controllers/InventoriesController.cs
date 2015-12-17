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
    [Authorize(Roles="Manager")]
    public class InventoriesController : Controller
    {
        private BikeStoreEntities db = new BikeStoreEntities();

        // GET: Inventories
        public ActionResult Index()
        {
            var inventories = db.Inventories.Include(i => i.Frame).Include(i => i.Store).Include(i => i.Type);
            return View(inventories.ToList());
        }

        // GET: Inventories/Details/5
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

        // GET: Inventories/Create
        public ActionResult Create()
        {
            ViewBag.Frameid = new SelectList(db.Frames, "FrameId", "FrameName");
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName");
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "TypeName");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventoryId,Frameid,TypeId,BrandName,ModelName,Desc,UnitPrice,SellingPrice,StoreId")] Inventory inventory)
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
            return View(inventory);
        }

        // GET: Inventories/Edit/5
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
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryId,Frameid,TypeId,BrandName,ModelName,Desc,UnitPrice,SellingPrice,StoreId")] Inventory inventory)
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
            return View(inventory);
        }

        // GET: Inventories/Delete/5
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

        // POST: Inventories/Delete/5
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
