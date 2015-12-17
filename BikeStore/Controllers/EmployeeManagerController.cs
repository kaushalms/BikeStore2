﻿using System;
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
    public class EmployeeManagerController : Controller
    {
        private BikeStoreEntities db = new BikeStoreEntities();

        // GET: EmployeeManager
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.EmployeeType).Include(e => e.Store);
            return View(employees.ToList());
        }

        // GET: EmployeeManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: EmployeeManager/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "EmployeeTypeId", "EmployeeTypeName");
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName");
            return View();
        }

        // POST: EmployeeManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmployeeName,EmployeeDOB,SSN,InvSold,EmployeeTypeId,StoreId,EmpPassword")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "EmployeeTypeId", "EmployeeTypeName", employee.EmployeeTypeId);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", employee.StoreId);
            return View(employee);
        }

        // GET: EmployeeManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "EmployeeTypeId", "EmployeeTypeName", employee.EmployeeTypeId);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", employee.StoreId);
            return View(employee);
        }

        // POST: EmployeeManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmployeeName,EmployeeDOB,SSN,InvSold,EmployeeTypeId,StoreId,EmpPassword")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeTypeId = new SelectList(db.EmployeeTypes, "EmployeeTypeId", "EmployeeTypeName", employee.EmployeeTypeId);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", employee.StoreId);
            return View(employee);
        }

        // GET: EmployeeManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: EmployeeManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
