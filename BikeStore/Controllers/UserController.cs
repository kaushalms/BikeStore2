using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeStore.Controllers
{
    public class UserController : Controller
    {
        BikeStoreEntities storeDB = new BikeStoreEntities();
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            // this action is for handle post (login)
            //if (ModelState.IsValid) // this is check validity
            {
                var v = storeDB.Users.Where(a => a.EmailId.Equals(u.EmailId) && a.Password.Equals(u.Password)).FirstOrDefault();
                if (v != null)
                {
                    Session["LogedUserID"] = v.UserID.ToString();
                    Session["LoggedEmail"] = v.EmailId.ToString();
                    Session["LoggedRole"] = "Customer";
                    return RedirectToAction("AfterLogin");
                }

            }
            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogin(User u)
        {
            // this action is for handle post (login)
            //if (ModelState.IsValid) // this is check validity
            {
                var v = storeDB.Users.Where(a => a.EmailId.Equals(u.EmailId) && a.Password.Equals(u.Password)).FirstOrDefault();
                if (v != null)
                {
                    Session["LogedUserID"] = v.UserID.ToString();
                    Session["LoggedEmail"] = v.EmailId.ToString();
                    Session["LoggedRole"] = "Customer";
                    return RedirectToAction("AfterUserLogin");
                }

            }
            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(User u)
        {
            // this action is for handle post (login)
            //if (ModelState.IsValid) // this is check validity
            {
                var v = storeDB.Employees.Where(a => a.EmployeeName.Equals(u.EmailId) && a.EmpPassword.Equals(u.Password)).FirstOrDefault();
                if (v != null)
                {
                    Session["LogedUserID"] = v.EmployeeId.ToString();
                    Session["LoggedEmail"] = v.EmployeeName.ToString();
                    EmployeeType employeeTypes = storeDB.EmployeeTypes.Where(e=>e.EmployeeTypeId==v.EmployeeTypeId).SingleOrDefault();
                    Session["LoggedRole"] = employeeTypes.EmployeeTypeName;
                    return RedirectToAction("AfterLogin");
                }

            }
            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User U)
        {
            if (ModelState.IsValid)
            {
                storeDB.Users.Add(U);
                storeDB.SaveChanges();
                ModelState.Clear();
                //U = null;
                ViewBag.Message = "Successfully Registration Done";

                var v = storeDB.Users.Where(a => a.EmailId.Equals(U.EmailId) && a.Password.Equals(U.Password)).FirstOrDefault();
                if (v != null)
                {
                    Session["LogedUserID"] = v.UserID.ToString();
                    Session["LoggedEmail"] = v.EmailId.ToString();
                    Session["LoggedRole"] = "Customer";
                    return RedirectToAction("AfterLogin");
                }
            }
            return View(U);
        }

        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult AfterUserLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}