﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hw_6.Models;
using System.Net;

namespace hw_6.Controllers
{
    public class HomeController : Controller
    {
        private ProductionContext db = new ProductionContext();

        /// <summary>
        /// GET: ProductCategories
        /// HttpGet method to retrieve the View for the Product Categories and
        /// related Product Subcategories
        /// </summary>
        /// <param name="id">The id of the ProductCategory for which to retrieve the
        /// relevant Subcategories</param>
        /// <returns>The View object for Home/Index/{id}</returns>
        public ActionResult Index(int? id)
        {
            var cat = db.ProductCategories;
            //determine if a ProductCategory was selected
            if (id != null && db.ProductCategories.Find(id) != null)
            {
                ViewBag.ID = id;
            }

            return View(cat);
        }

        /// <summary>
        /// GET: Products
        /// HttpGet method to retrieve the View for the Products contained within
        /// the selected Subcategory (id)
        /// </summary>
        /// <param name="id">The id of the Subcategory to which to retrieve the Products</param>
        /// <param name="page">The current page number when there are a large amount of products</param>
        /// <returns>The View object for Home/Products/{id}?{page=}</returns>
        public ActionResult SubProducts(int? id, int? page = 1)
        {
            if (id == null || db.ProductSubcategories.Find(id) == null)
                return RedirectToAction("Index"); // subcategory doens't exists or not denoted

            var products = db.ProductSubcategories.Find(id).Products.ToList();

            int pageSize = 6; // # of items to view per page
            double numOfPages = Math.Ceiling((double)products.Count / pageSize); // # of pages

            int pageNumber = page ?? 0;
            if (page < 1 || page > numOfPages)
                return HttpNotFound(); // invalid page number

            ViewBag.NumberOfPages = numOfPages;

            // get the appropriate items based on the page number
            var productsPaged = products.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

            return View(productsPaged);
        }

        /// <summary>
        /// GET: Product
        /// HttpGet method to retrieve the View for the desired Product
        /// </summary>
        /// <param name="id">The id of the desired Product</param>
        /// <returns>The View object for Products/Product/{id}</returns>
        public ActionResult Products(int? id)
        {
            if (id == null) // product id wasn't indicated
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = db.Products.Find(id);

            if (product == null) // product doesn't exist
                return HttpNotFound();

            // get the number of product reviews, and if not 0, calculate the overall product rating
            ViewBag.NumOfReviews = product.ProductReviews.Count;
         
            // get the unit of measure for the product size if it has one
            var sizeUnit = product.SizeUnitMeasureCode;
            ViewBag.SizeUnit = sizeUnit == null ? "N/A" : product.SizeUnitMeasureCode.ToLower();

            // get the unit of measure for the product weight if it has one
            var weightUnit = product.WeightUnitMeasureCode;
            ViewBag.WeightUnit = weightUnit == null ? "N/A" : product.WeightUnitMeasureCode.ToLower();

            return View(product);
        }

        

        /// <summary>
        /// GET: Review
        /// Method to retrieve the View for creating a Review of the desired Product
        /// </summary>
        /// <param name="id">The id of the Product for which to create a Review</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Review(int? id)
        {
            int pid = id ?? -1;
            if (pid == -1) // id was not indicated
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = db.Products.Find(pid);

            if (product == null) // product doesn't exist
                return HttpNotFound();

            // Create a new ProductReview for this Product, prepopulate dictated info and send to View
            ProductReview review = db.ProductReviews.Create();
            review.ProductID = pid;
            review.Product = product;
            review.ReviewDate = review.ModifiedDate = DateTime.Now;

            return View(review);
        }

        /// <summary>
        /// POST: Review
        /// Validates and creates a ProductReview from the user input
        /// </summary>
        /// <param name="review">The ProductReview to validate and add to database</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Review(ProductReview review)
        {
            // if valid, add to db and redirect back to Product page
            if (ModelState.IsValid)
            {
                db.ProductReviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("SubProducts", new { id = review.ProductID });
            }
            // return prepopulated model back to user if not valid
            review.Product = db.Products.Find(review.ProductID);
            return View(review);
        }

    }
}