using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Services.Description;
using System.Text.RegularExpressions;

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

        //GET ~/HOME/Page2
        [HttpGet]
        public ActionResult Page2()
        {
            ViewBag.RequestMethod = "GET";
            return View();
        }

        //POST ~/HOME/Page2
        [HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            ViewBag.RequestMethod = "POST";
            string firstSlang = Request.Form["firstDrop"];
            string secondSlang = Request.Form["secondDrop"];

            string compoundSlang;

            //if-else statement for first drop down box
            if (firstSlang == "ofCourse")
            {
                firstSlang = "fasho";
            }
            else if (firstSlang == "pickup")
            {
                firstSlang = "swoop";
            }
            else if (firstSlang == "dyu")
            {
                firstSlang = "yaddamean";
            }
            else if (firstSlang == "very")
            {
                firstSlang = "hella";
            }
            else if (firstSlang == "tryingTo")
            {
                firstSlang = "tryna";
            }
            else if (firstSlang == "yes")
            {
                firstSlang = "yee";
            }

            //if-else statement for second drop down box
            if (secondSlang == "friend")
            {
                secondSlang = "cuddy";
            }
            else if (secondSlang == "cars")
            {
                secondSlang = "whips";
            }
            else if (secondSlang == "cool")
            {
                secondSlang = "wet";
            }
            else if (secondSlang == "leave")
            {
                secondSlang = "dip";
            }
            else if (secondSlang == "crazy")
            {
                secondSlang = "hyphy";
            }
            else if (secondSlang == "wrong")
            {
                secondSlang = "outta pocket";
            }

            compoundSlang = firstSlang + " " + secondSlang;
            ViewBag.Message = compoundSlang;
            return View();
        }


        // GET ~/Home/Page3
        [HttpGet]
        public ActionResult Page3()
        {
            ViewBag.RequestMethod = "GET";
            return View();
        }

        /// <summary>
        /// Process a POSTed form. Returns
        /// the answer in the ViewBag.
        /// </summary>
        /// (? after paramenter type means nullable)
        /// <param name="amount">loan amount </param>
        /// <param name="interestRate">the interest on the loan</param>
        /// <param name="numOfYears">number of years </param>
        /// <returns>loan payment monthly amount in a View</returns>
        [HttpPost]
        public ActionResult Page3(double? amount, double? interestRate, double? numOfYears)
        {


            // rate of interest and number of payments for monthly payments
            var rateOfInterest = interestRate / 1200;
            var numberOfPayments = numOfYears * 12;

            // loan amount = (interest rate * loan amount) / (1 - (1 + interest rate)^(number of payments * -1))
            var paymentAmount = ((rateOfInterest * amount) / (1 - Math.Pow(((double)(1 + rateOfInterest)), ((double)(numberOfPayments * -1)))));

            ViewBag.Answer = Math.Round((decimal)paymentAmount, 2);

            return View();

        }
    }
}




