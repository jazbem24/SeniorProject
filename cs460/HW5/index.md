# Homework 5 

For this assignment, the goal was to make a web app using the ASP.NET MVC 5 framework with a database to back it. During this assignment, I learned how to make a database first, and then add the functionality to the webpage afterwards.

# Step 1 

First, I created my enviroment. Which was a little tricky, considering I use a mac and the aspects of Visual Studio that I needed are only available through Windows. I got to learn a lot more about virtual machines though, which has been a blessing in disguise. 

# Step 2

After I created a new solution in Visual studio, I started with the data model. In visual studio, I was able to create a db_UP.sql file with the definition for the database for the local SQL Server to create. Also, created a db_DOWN.sql file to remove the table. These files were created in the App_Data folder. I ran these scripts to create the database

# Step 3 

Next, I crated the model class and db context class. The model class created a framework for the data to uphold. The db context class works as the data access layer into my application. In other words, it links the model properties to my database with a connection string. 

Model snippet... 
```
        [Display(Name = "ID")]
        public int id { get; set; }
    
        [Display(Name = "DOB")]
        public DateTime Dob { get; set; }

        [Display(Name = "Customer Number")]
        public int customerNumber { get; set; }

        [Display(Name = "Full Name")]
        public string fullName { get; set; }
```

db context snippet...
```
  public class AddressContext : DbContext
    {
        public AddressContext() : base("name=OurDBContext")
        { }

        public virtual DbSet<Address> Addresses { get; set; }
    }
```
example of connection string found in the Web.config file...
```
add name="OurDBContext"
connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jazmin\Desktop\seniorproject\SeniorProject\cs460\HW5\hw5\hw5\App_Data\AddressDB.mdf;Integrated Security=True" providerName="System.Data.SqlClient"
```

# Step 4

After laying down the db, I created the controllers and action methods to add functionality. I created a get methods for the index, AddForm, and List pages,as well as a post method that bound the new address object to page. 

Funny tid bit about this, I kept getting a dateTime2 error, and couldn't figure out why for the longest...then it occurred to me that I was missing the current date attribute... 

```
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
```

# Step 5 

Lastly, I created the strongly typed views and added a little bit of css to the site.css file. 

snippet from AddForm View... 

```
@model hw5.Models.Address

@{
    ViewBag.Title = "AddForm";
}
<h1>Add Form</h1>

@using (Html.BeginForm())
{
    <h4>Address</h4>
    <div class="form-group">
        @Html.LabelFor(model => model.fullName, htmlAttributes: new { @class = "control-label col-md-2" })
        <div class="col-md-10">
            @Html.EditorFor(model => model.fullName, new { htmlAttributes = new { required = "required", @class = "form-control" } })
            @Html.ValidationMessageFor(model => model.fullName, "", new { @class = "text-danger" })
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(model => model.Dob, htmlAttributes: new { @class = "control-label col-md-2" })
        <div class="col-md-10">
            @Html.EditorFor(model => model.Dob, new { htmlAttributes = new { required = "required", @class = "form-control" } })
            @Html.ValidationMessageFor(model => model.Dob, "", new { @class = "text-danger" })
        </div>
    </div>
```

# Now here's some screenshots exhibiting it in action... 
