using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hw_8.Models;

namespace hw_8.Controllers
{
    public class HomeController : Controller
    {
        private ArtistryContext db = new ArtistryContext();

        // GET: Home
        public ActionResult Index()
        {
            List<Genre> genre = db.Genres.ToList();
            return View(genre);
        }


        public JsonResult GetGenre(int? genre)
        {
            if(genre == null)
            {
                return null;
            }

           var artPieces = db.Genres.Where(g => g.ID == genre)
                        .Select(a => a.Classifications)
                        .FirstOrDefault()
                        .Select(a => new { a.ArtWork.Title, a.ArtWork.Artist.ArtistName })
                        .OrderBy(a => a.Title)
                        .ToList();
                       
            return Json(artPieces, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Classifications()
        {
            return View(db.Classifications.ToList());
        }
        
        [HttpGet]
        public ActionResult ArtWorks()
        {
            return View(db.Artworks.ToList());
        }
        [HttpGet]
        public ActionResult Artists()
        {
            return View(db.Artists.ToList());
        }

        [HttpGet]
        public ActionResult ArtistDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpGet]
        public ActionResult CreateArtist()
        {
            return View();
        }

        // POST: Home/CreateArtists
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtist([Bind(Include = "ID,ArtistName,BirthDate,BirthPlace")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Artists");
            }

            return View(artist);
        }

        [HttpGet]
        public ActionResult EditArtist(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Home/EditArtist/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArtist([Bind(Include = "ID,ArtistName,BirthDate,BirthPlace")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Artists");
            }
            return View(artist);
        }

        [HttpGet]
        public ActionResult DeleteArtist(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("DeleteArtist")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteArtistConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Artists");
        }
    }
}
