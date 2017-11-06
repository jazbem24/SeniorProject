# Homework 2 

For this assignment, the goal is to demonstrate basic understanding of HTML, CSS, and Javascript and how they all work together to make a responsive website. 

# Step 1: Set up the Enviroment 

First, I need to set up my enviroment. I started by creating a HW2 directory, and created a style.css and index.html, since those are needed. Also, I created a index.md file to start journaling the process.

```
 mkdir HW2
 cd HW2
 touch style.css
 touch index.html
 touch index.md 
 ```
 Next, I created a  new branch to start working.
 
 ```
 git branch feature_branch master
 git checkout feature_branch
  ```
  
Now that I have place to start, I added the files and pushed the branch to the remote repo.

```
 git add . 
 git commit -m "Added hw2 files" 
 git push origin hw_2
 ```
# Step 2: Creating a Wireframe

Now that I have a good starting point, I need to create a wireframe to use as a layout for the website. I creatd this wireframe using MockFlow. MockFlow is an online wireframe,prototyping,and UI mockup tool. 

![Wireframe](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW2/ref/wireframe.png)

# Step 3: Create the Webpage

After creating the wireframe, I added added jquery and javascript to the file for added logic and grabbing element value from the DOM. 

```
 console.log('got the document');
        $(document).ready(function() {;
           $("#button").click(function() {
               
               var ounces = document.getElementById("OuncesConsumed").value; 
               var gender = document.getElementById("gender").value; 
               var h = document.getElementById("hours").value;
               var pounds = document.getElementById("lbs").value;
               
               var g;
               var bac; 
            
               if(gender = "male"){
                    g= 0.73;
                 }
                 else {
                 g = 0.66; 
                 }  
                var j = ounces * 5.14; 
                var r = j / pounds * g;
                bac = Number(r - 0.15 * h).toFixed(2); 
               $("#list").append(`<ul>
                    <li>${bac}%</li>
                    <li>BAC .02%-.03%-doing just fine</li>
                    <li>BAC .10%-.12%-definitely should get a taxi home</li>
                    </ul> `);
               console.log('it worked');
           }); 
        });
```

Next, added some css for style points. 

```
.form-body {
    color: blueviolet;
    text-align: center;
    margin:10x 30px; 
    font-family: verdana;
    font-weight: bolder;
    border-color: black;
    border-style: solid;
    
}

.form-row {
    text-align: center;
}

.words{
    border-color: black;
    border-style: solid;
    text-align: center;
    font-weight: bold; 

}

```

# Step 4: BAC Calculator in action 

Before... 

![Wireframe](https://github.com/jazbem24/SeniorProject/blob/hw_2/cs460/HW2/ref/hw2before.png)

After...

 
![Wireframe](https://github.com/jazbem24/SeniorProject/blob/hw_2/cs460/HW2/ref/hw2after.png)
 
 