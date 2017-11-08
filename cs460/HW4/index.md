# Homework 4 

The purpose of this homework assignment was to start learning about MVC (Model, View, Controller) projects and how to send data from the browser to the server, in different ways, in order to see the options I have when creating dynamic web pages with form data. 

# Step 1 - Creating a new MVC project and creating feature branches

First, I downloaded and install Visual Studio 2017 Community for Mac.(which takes a lot longer than one would think). After that, I created 3 branches each for my different branches. 

```
git branch hw_4_home master
git checkout hw_4_home
git branch hw_4_page1 master
git checkout hw_4_page1
git branch hw_4_page2 master
git checkout hw_4_page2
git branch hw_4_page3 master
git checkout hw_4_page3
```
# Step 2 - create a home Index View with Razor Html Action Links and a shared layout as well in true bootstrap fashion  

```
<div class="pageList">
<ul>
    <li class="pageListItem">@Html.ActionLink("USD to CAD", "Page1", "Home")</li>
    <li class="pageListItem">@Html.ActionLink("Bay Area Slang Converter", "Page2", "Home")</li>
    <li class="pageListItem">@Html.ActionLink("Loan Calculator", "Page3", "Home")</li>
</ul>
</div>
```

![Wireframe](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW4/ref/home.png)

# Step 3 - Create page 1 with a View and ActionResult() method in the HomeController 

For page 1, I created a USD to CAD converter. I used a ViewBag to get the data from the View and used a HTTP get method to add some logic. 

```
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
```
![Wireframe](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW4/ref/page1start.png)

![Wireframe](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW4/ref/page1working.png)
    
# Step 4 = Create page 2 with a View and ActionResult() method in the HomeController using a FormCollection and HTTP Post method 
 
For page 2, I created a Bay Area Slang translator. I thought this would be fun since that's where my orgins lie. With the method in the HomeController, I was able to POST values that could be retrieved by the FormCollection object. Here's some code from the POST method... 

```
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
```


![Wireframe](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW4/ref/page2start.png)
![Wireframe](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW4/ref/page2working.png)

# Step 5 - Lastly, I created a Loan Calculator to emulate model minding. I got to use the '?' in C# with the parameters that I brought in from the View. The '?' makes the parameters nullable. After I finshed with the Controller and the Views, I pushed each feature to the remote repo and merges them into master from the command line. 

``` 
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
```

![Wireframe](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW4/ref/page3start.png)
![Wireframe](https://github.com/jazbem24/SeniorProject/tree/master/cs460/HW4/ref)