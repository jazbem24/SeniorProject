# Homework 6 

** Deploying a MVC App With a "Code First Existing Database"** 

# Step 1: Downloading AdventureWorks 2014

The database we used for this project was the AdventureWorks database for a fictional outdoor/recreation store that is similar to the likes of REI. 

I got this database from [github](https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/adventure-works)

# Step 2: Use the .bak file to make a .ldf and .mdf file 

Next, I needed to restore the database. I used these commands: 

```
RESTORE DATABASE AdventureWorksDW2014
FROM disk= 'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\Backup\AdventureWorksDW2014.bak'
WITH MOVE 'AdventureWorksDW2014_data' 
TO 'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\AdventureWorksDW2014.mdf',
MOVE 'AdventureWorksDW2014_Log' 
TO 'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\AdventureWorksDW2014.ldf'
,REPLACE
```

# Step 3: Use Reverse Engineer Model from Entity Framework to Bring in Data Models/Context

After restoring the database, I reverse engineered the model from the database to bring in the Production tables. I used this [website](https://msdn.microsoft.com/en-us/library/jj200620(v=vs.113).aspx) as a reference. 

# Step 4: Creating buttons for each product and subproduct for the home page. 

Next, I created buttons arranged in a dropdown format to demostrate each item. 

```
<h2>Product Categories</h2>
    <ul class="list-group col-md-4">
       
        <!-- Create a list of links for all of the different products  -->
        @foreach (var item in Model.ToList())
        {
            @Html.ActionLink(item.Name, "Index/" + item.ProductCategoryID, new { controller = "Home" }, new { @class = "list-group-item" })
        }
    </ul>
    <div class="col-md-offset-1 col-md-4">
        <!--if the category is not null, grab the product, and subproduct after-->
        @if (ViewBag.ID != null)
        {
            <h2>@Model.Where(p => p.ProductCategoryID == ViewBag.ID).FirstOrDefault().Name</h2> 
            <ul class="list-group">
                @foreach (var item in Model.Where(p => p.ProductCategoryID == ViewBag.ID).Select(p => p.ProductSubcategories).ToList().FirstOrDefault())
                {
                    @Html.ActionLink(item.Name, "SubProducts/" + item.ProductSubcategoryID, new { controller = "Home" }, new { @class = "list-group-item" })
                }
            </ul>
        }
```

# Step 5: Added a view for each product within a category and added pagination. Also added some logic to the controller. 

Here I create a view and add pagination in order to see all of the products. 

```
div class="row">
    <!-- Display name, product number, and price of each item -->
    @foreach (var item in Model)
    {
        <center>
            <div class="col-md-4" style="padding-bottom: 2em">
                <div>
                    <!-- Product name is the link to that product's details page -->
                    <strong>@Html.ActionLink(item.Name, "Products", new { id = item.ProductID })</strong>
                </div>
                <div>
                    Product #: @Html.DisplayFor(modelItem => item.ProductNumber)
                </div>
                <div>
                    <strong>$@Html.DisplayFor(modelItem => item.ListPrice)</strong>
                </div>
            </div>
        </center>
    }
</div>
```
```
<br />
<!-- Create page links for the number of pages in this subcategory -->
<div>
    <ul class="pagination">
        @for (int i = 1; i <= ViewBag.NumberofPages; ++i)
        {
            <li>@Html.ActionLink(i.ToString(), "Products", new { id = Model.FirstOrDefault().ProductSubcategoryID, page = i })</li>
        }

```
# Step 6: Adding Review Functionality 

After implementing the pagination, I was able to make it possible to leave a review and see the list of reviews. 

Here is some example code from the review form from the view: 
```
  <div class="form-group">
            @Html.LabelFor(model => model.EmailAddress, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.EmailAddress, new { htmlAttributes = new { @class = "form-control", @placeholder = "janedoe@myemail.com" } })
                @Html.ValidationMessageFor(model => model.EmailAddress, "", new { @class = "text-danger" })
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(model => model.Rating, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Rating, new { htmlAttributes = new { @class = "form-control", @min = "1", @max = "5", @maxlength = "1", @Value = "5" } })
                @Html.ValidationMessageFor(model => model.Rating, "", new { @class = "text-danger" })
            </div>
        </div>

```
And some logic from the controller: 
```
[HttpGet]
        public ActionResult Reviews(int? id)
        {
            int pid = id ?? -1; //initialized to -1 since it isn't a valid id 
            if (pid == -1) // id was not indicated
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            var product = db.Products.Find(pid);

            if (product == null) // product doesn't exist
                return HttpNotFound();

            // Create a new ProductReview for this Product and add needed values
            ProductReview review = db.ProductReviews.Create();
            review.ProductID = pid;
            review.Product = product;
            review.ReviewDate = review.ModifiedDate = DateTime.Now;

            return View(review);
        }

```

Lastly I added some css work: 

```
}
.jumbotron {
    text-align: center;
    background-image: url(/Ref/biking.jpg);
    background-size: auto 100%;
}
/* Set width on the form input elements since they're 100% wide by default */
input,
select,
textarea {
    max-width: 280px;
}

.jumbowords {
    color: white;
}
```

# Screenshots of it in action: 

![My helpful screenshot]({{ https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW6/ref/homepage.png }} /ref/homepage.png)

![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW6/ref/homepage.png)

![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW6/ref/Components.png)

![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW6/ref/Handlebars.png)

![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW6/ref/pageDisplay.png)


![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW6/ref/singleproduct.png)


![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW6/ref/writeareview.png)

<img src="{{ site.baseurl }}/assets/img/hp_narrators.png">

