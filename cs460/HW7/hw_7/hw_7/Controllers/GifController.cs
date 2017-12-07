using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hw_7.Models;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace hw_7.Controllers
{
    public class GifController : Controller
    {
        SearchLogContext db = new SearchLogContext(); 
       
            public ActionResult Index()
        {
            return View();
        }

        // GET: Search
        /// <summary>
        /// get the json results for the gif search 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Search()
        {
            
            //the building of the uniform resource identifier(URI)
            string key = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"]; //get the key
            string str = "http://api.giphy.com/v1/gifs/search?api_key="
                             + key
                             + "&q="
                             + Request.QueryString["find"];
         
                       
            //create web request and recieve the data stream from giphy
            WebRequest request = WebRequest.Create(str);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            //deserialize the json objects
            string result = reader.ReadToEnd();
            var foo = new JavaScriptSerializer().DeserializeObject(result);

                //close the response/web request streams 
                 response.Close();
                dataStream.Close();
         
            //Get the user's information
            string ipAddress = Request.UserHostAddress;
            string userAgent = Request.UserAgent;
            string search = Request.QueryString["find"];

            //New DataLog object for storing the user's information
            SearchLog sl = new SearchLog();

            //Store the querying user's information
            sl.IPAddress = ipAddress;
            sl.Agent = userAgent;
            sl.SearchDate = DateTime.Now;
            sl.SearchRequest = search;

            //Add the object to the database
            db.SearchLogs.Add(sl);
            db.SaveChanges();

            //Return the results to the calling method
            return Json(foo, JsonRequestBehavior.AllowGet);
        }
    }
}