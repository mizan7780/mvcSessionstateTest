using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSessionState.Controllers
{
    public class OurController : Controller
    {
        Models.OurDatabaseEntities de = new Models.OurDatabaseEntities();
        //
        // GET: /Our/
        [HttpPost]
        public ActionResult ProfilePage(FormCollection profile)
        {
            Models.ProfileTable p = new Models.ProfileTable();
            p.firstName = profile[0].ToString();
            p.lastName = profile[1].ToString();
            p.userAddress = profile[2].ToString();
            p.userName = Session["myName"].ToString();
            de.ProfileTables.Add(p);
            de.SaveChanges();
            return View();
        }
        public ActionResult ProfilePage()
        {
            string str = Session["myName"].ToString();
            var result = from p in de.ProfileTables
                         where p.userName == str
                         select p;
            if(result.Count()==1)
            {
                
            }
            else
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult login(FormCollection frm)
        {
            string strUName=frm[0].ToString();
            string strUPass=frm[1].ToString();
            var result = from u in de.UserTables
                         where u.userName == strUName && u.userPassword == strUPass && u.userStatus=="a"
                         select u;
            if(result.Count()==1)
            {
                //valid user
                Session["myName"] = strUName;
                return RedirectToAction("ProfilePage");
            }
            else
            {
                //invalid user
                ViewBag.msg = "User Name or Password is invalid!!!";
                return View();
            }
        }
        public ActionResult login()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Our/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Our/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Our/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Our/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Our/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Our/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Our/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
