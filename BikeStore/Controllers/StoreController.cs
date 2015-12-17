using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeStore.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        BikeStoreEntities storeDB = new BikeStoreEntities();

        public ActionResult Index()
        {
            var stores = storeDB.Stores.ToList();
            return View(stores);
        }

        //public ActionResult BrowseType(int store)
        //{
        //    var types = storeDB.Types.ToList();
        //    ViewBag.StoreSelected = store;
        //    return View(types);

        //}




        public ActionResult Browse(int store)
        {
            var inventoryModel = storeDB.Inventories.ToList().Where(s => s.StoreId == store);
            return View(inventoryModel);
        }

        public ActionResult Details (int id)
        {
            var inventory = storeDB.Inventories.Find(id);
            ViewBag.ProdStatusName = storeDB.ProdStatuss.Where(p => p.ProdStatusId == inventory.ProdStatusId);
            return View(inventory);

        }



    }
}