# Homework 8: MVC App With DIY Relational Multi-Table Database 

# Step 1: Domain Model

To Start, I created a domain model with 4 entities: Artists, Genres, Artworks, and Classifications. I ran an UP sql script file to fill create the tables, and later inserted seed data into the tables. (Also created a down script to drop the tables)

Examples of the Artists and ArtWorks tables...
```
CREATE TABLE dbo.Artists(
ID int IDENTITY(1,1) NOT NULL,
ArtistName varchar(128) NOT NULL,
BirthDate date NOT NULL,
BirthPlace varchar(128) NOT NULL
CONSTRAINT[PK.dbo.Artists] PRIMARY KEY CLUSTERED(ID ASC)
);

--create ArtWork table 
CREATE TABLE dbo.ArtWorks(
ID int IDENTITY(1,1) NOT NULL,
Title varchar(86) NOT NULL,
ArtistID int NOT NULL, 
CONSTRAINT[PK.dbo.ArtWork] PRIMARY KEY CLUSTERED(ID ASC),
CONSTRAINT[FK_dbo.Artworks_dbo.ArtistID] FOREIGN KEY ([ArtistID])REFERENCES [dbo].[Artists]([ID])
);

```
# Step 2: Creating Context for the App Using Entity Framework

Next, I brought the database context into the app so that I could make use of it in the app. 

```
namespace hw_8.Models
{
    public partial class ArtistryContext: DbContext
    {
       public ArtistryContext()
            :base("name=ArtistryContext")
        {
        }
        
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtWork> Artworks { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Classifications> Classifications { get; set; }

```
# Step 3: Creating a Menu On the Shared Layout

After bringing in the context, I created a menu in the navigation bar to show all the artists, artworks, and classifications. 

![Alt Text](/ref/menu.png)

# Step 4: CRUD Functionality For Artist

Later, I added a scaffolded item with views and a controller via Entity Framework to create CRUD (create, read, update, delete) functionality for the Artist. 

![Alt Text](/ref/crud.png)

# Step 5: Attribute Checking

After creating the CRUD functionality, I added attribute checking the the Artist Edit page to ensure that none of the field were optional. 

![Alt Text](/ref/required.png)

# Step 6: AJAX implementation

Lastly, I created buttons on the home page for ever genre. Each time one those buttons are clicked, it displays artworks and titles in that genre, sorted by title. I did this by using the AJAX technique in my genre.js file. AJAX stands for Asynchrous JavaScript and XML. 

```
function displayGenre(data) {
    console.log("Ajax working");
    console.log(data);
    $("#genreList").empty();

    $.each(data, function (i, obj) {
        $("#genreList").append("<li>" + obj["Title"] + " "+ "by" + " " + obj["ArtistName"] + "</li>");
    });
    $("#ShowList").css("display", "block");
}



$(".genreButton").click(function () {
    var genre = $(this).val();
    var source = "/Home/GetGenre/" + genre;
    console.log(source);
    $.ajax({
        type: "GET",
        datatype: "json",
        data:{genre},
        url: source,
        success: function (data){
            displayGenre(data);
        }
    });
});

```
![Alt Text](/ref/ajax.png)

![Alt Text](/ref/ajax2.png)


I also returned the appropriate JSON object in order to make this happen... 

```
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

```


