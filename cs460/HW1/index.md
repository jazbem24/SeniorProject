# Homework 1 

For this first homework, we’re tasked with learning the basics of HTML and CSS, while practicing Git. To aid in creating decent looking web pages we’re also supposed to use Bootstrap, which I’ve learned is a popular CSS and Javascript library for page layout.

The assignment page can be found here. Despite the rather lengthy description, this HW is basically asking for a simple set of web pages.

Let’s get started …

# Step 1: Dowload Git, Learn a Basic Workflow, Creat Accounts on GitHub

I’ve downloaded `clone` ed software from GitHub before, and browsed through code there, but I’ve never had to learn Git. I downloaded the offical Git software from [Git-scm](https://git-scm.com/). After reading some tutorials and watching a couple YouTube videos on Git I’m ready to dive in.

I first created a repository on Bitbucket, then added a README through their web interface. To get a local copy on my machine I had to clone it and then make sure everything is set up correctly. The instructor wants us to do everything through the command line, so we fire up Git Bash 

```
cd Documents/CS460
mkdir repos
cd repos
git clone git@github.com:jazbem24/bembryj.git
cd myprojectname

```

Now to add some code and see if we can push up to the remote server:

```
echo "# README" >> README.md
git add README.md
git commit -m "Initial commit; create a project README"
git push -u origin master       # the -u flag adds upstream tracking reference -- will have to look this one up
```

# Step 2:HTML, CSS, Bootstrap

First I created a main index HTML file and brought Bootstrap into my project using the Bootstrap Max CDN as well as a reference to my style.css file. 

```
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>Homework 1</title>
        <!-- Latest compiled and minified CSS -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
        <!-- Latest compiled and minified JavaScript -->
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
        <link rel="stylesheet" type="text/css" href="style.css">
    </head>
```
 
 Next, I created a navigation bar with links to the HTML files I created for each page on the website.
 
 ```
   <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="index.html">Home</a></li>
                    <li><a href="history.html">History of Portland Rap/Hip-Hop</a></li>
                    <li><a href="artists.html">Today's Popular Portland Rap Artists</a></li>
                    <li><a href="places.html">Where to find Portland Rap/Hip-hop</a></li>      
                </ul>
            </div>
        </nav>
 ```
 
 After, I spent some time implementing the pages with text,links,a table, images,lists, and a page with 2 columns. For example, I was able to add images, a paragraph, and a link to some cells in a table on the website like this...
 
 ```
 <td>Amine'</td>
                <td><img src="amine.jpg" alt="HTML5 Icon"style="width:120px;height:120px;"></td> 
                <td><p>Amine', 23, reigns from Portland,Oregon and is the son of Ethioian and Eritean immigrants. He briefly attended Portland State and studied marketing. He became a sensation when his debut single, "Caroline", made it to the 11th spot on the Top 100 BillBoard Charts. His debut album, Good For You, was released in July of 2017. </p></td>
                <td><a href="https://twitter.com/heyamine?lang=en">Amine's Twitter Page</a></td>  
 ```

When I finished implementing the pages, I implemented the style.css file to give my page some style.
Some example code: 

```
body {
    background-color: lightblue;
    border-style: solid;
    border-color: silver;
    border-width: 200px;
    margin:auto;

}

h1 {
    color: white;
    text-align: center;
    margin: 0 0 50px 0;
    font-family: verdana;
    font-weight: bold;
}
p, p2, p3, ol,p4,p5{
    font-weight: bolder;
}
```

# Step 3: GitHub Pages 

Afte I was done creating the website, I created a GitHub Page fro this repository to be seen as a Porfolio. I chose a Jekyll theme and added markdown files to my main repo folder and HW1. When I was finished with that, GitHub Pages did some magic and turned my files into a live Portfolio on the web. 


[Portfolio Main Page](https://jazbem24.github.io/SeniorProject/)

[Link to Website Created](https://jazbem24.github.io/SeniorProject/cs460/HW1/HW1.html)
 
[Full Code for HW1 Found Here](https://github.com/jazbem24/SeniorProject/tree/master/cs460/HW1)