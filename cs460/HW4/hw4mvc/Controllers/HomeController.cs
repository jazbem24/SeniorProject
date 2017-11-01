using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace hw4mvc.Controllers
{
    public class HomeController : Controller
    {

        // Controller Action Methods
        // GET ~/Home/Index
        // GET ~/Home
        // GET ~/
        public ActionResult Index()
        {
            Debug.WriteLine("In Home Index()");
            return View();
        }

        // GET ~/Home/Page1
        public ActionResult Page1()
        {
            return View();
        }

        // GET ~/Home/Page2
        public ActionResult Page2()
        {
            return View();
        }

        // GET ~/Home/Page3
        public ActionResult Page3()
        {
            return View();
        }

    }
}
