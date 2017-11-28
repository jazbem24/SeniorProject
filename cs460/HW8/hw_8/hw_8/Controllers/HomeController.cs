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
        public ActionResult Artists()
        {
            return View(db.Artists.ToList());
        }

        // GET: Home/Details/5
        public ActionResult ArtistsDetails(int? id)
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

        // GET: Home/CreateArtists
        public ActionResult CreateArtists()
        {
            return View();
        }

        // POST: Home/CreateArtists
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtists([Bind(Include = "ID,ArtistName,BirthDate,BirthCity")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Artists");
            }

            return View(artist);
        }

        // GET: Home/EditArtist/5
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
        public ActionResult EditArtist([Bind(Include = "ID,ArtistName,BirthDate,BirthCity")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Artists");
            }
            return View(artist);
        }

        // GET: Home/DeleteArtist/5
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
