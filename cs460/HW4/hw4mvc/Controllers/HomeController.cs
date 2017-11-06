using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Services.Description;

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

        // GET ~/Home/page1
        [HttpGet]
        public ActionResult Page1()
        {

            string output = "You Now Have:";
            string money = Request.QueryString["money"];
            string conversionTo = Request.QueryString["conversionTo"];
            ViewBag.RequestMethod = "GET";
            double answer;

            //the conversion to USD
            if (conversionTo == "USD" || conversionTo == "usd")
            {
                answer = (double.Parse(money) * 1.28);
                output = "" + answer;
            }

            //the conversion to CAD
            else if (conversionTo == "CAD" || conversionTo == "cad")
            {
                answer = (double.Parse(money) / 1.28);
                output = "" + answer;
            }

            ViewBag.Message = output;
            return View();
        }

        // Get for page2
        [HttpGet]
        public ActionResult Page2()
        {
            ViewBag.RequestMethod = "GET";
            return View();

        }

        // GET ~/Home/Page3
        public ActionResult Page3()
        {
            return View();
        }

    }
}
