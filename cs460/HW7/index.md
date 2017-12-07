# Homework 7: AJAX Single Page App 

# Step 1: Make a Single Page

To start, I made a single page to display the gifs from giphy. 

![Alt Text](/ref/homepage.png)

I used the API docs from [Giphy](https://developers.giphy.com/docs/#search-endpoint) to understand the the functionality and implentation of their Search API to create a gif search page. I also registered as a developer to get an API key. 

# Step 2: Creating a Gif Controller and Javascript file with AJAX

Next I created a gif.js file to use to create a responsive page that will load the gifs related to the text that is inputted in the the text box. Unfortunately, I wasn't able to get it to work in the time that I alotted myself. I will need to spend more time on it later, but here is what I have started with. 

```

function searching() {
    $.ajax({
        url: "Gif/Search",
        type: "Get",
        data: {
            search: (document.getElementById('textInsert').nodeValue)
        },
        success: function (data) {
            data.data.forEach(function (item) {
                {
                    $('#foo').append(`img src = "${item}"`);

                }
            }
      });
 
}
```
In order to get the JSON results back, I created a search function in the Gif controller that grabs the key from my hidden file and creates a path with request parameters to get desired results. 

```
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
         
```

# Step 3: Add Database for A Search Log

Next, I created a database to be able to store the requests through the page. I used this up script... 
```
REATE TABLE SearchLog
(
	ID INT IDENTITY (1,1) NOT NULL,
	SearchDate DateTime NOT NULL,
	SearchRequest VARCHAR(MAX) NOT NULL,
	Agent VARCHAR(MAX) NOT NULL,
	IPAddress VARCHAR(128),
	CONSTRAINT [PK_SearchLog] PRIMARY KEY (ID)
);
```

# Step 4: Add functionality in the Gif Controller to Store Requests in the Database 

I added a search log object to the search function in the Gif Controller to store the request. 

```
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

```

# Step 4: Hidding the API Key

Next, I created App Settings Config to my Web.Config file to point to the hidden file with my API key in my file system. 

```
 <appSettings file="C:\Users\Jazmin\Desktop\apikey">
    <add key="webpages:Version" value="3.0.0.0" />
    <add key="webpages:Enabled" value="false" />
    <add key="ClientValidationEnabled" value="true" />
    <add key="UnobtrusiveJavaScriptEnabled" value="true" />
  </appSettings>
```

# Step 5: Custom Route

Another requirement for the HW was to make a custom route, so I created one to point to the search function in my gif controller based on the find query string. 

```
//find acts as a query string for the specific search
            routes.MapRoute(
                name: "MyRoute",
                url: "{gif}/{action}/{find}",
                defaults: new {controller = "Gif", action = "Search", find = UrlParameter.Optional }
            );
```

