using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hw5.DAL;
using hw5.Models;

namespace hw5.Controllers
{
    public class HomeController : Controller
    {
        private AddressContext db = new AddressContext(); 
        
        //GET: Home/Index
            public ActionResult Index()
        {
            return View();
        }

        //GET: Add Address Form
        public ActionResult AddForm()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddForm([Bind(Include = "customerNumber,dob, fullName,city,street,zip,st, currentDate")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(address);
        }
        //Get List of Addresses
        public ActionResult List()
        {
            return View(db.Addresses.ToList());
        }
    }
}