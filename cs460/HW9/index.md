# Homework 9 

**Deploying to the Cloud (Azure)**

# Step 1: Making an Account

To start, I made an account on Azure thanks to the Microsoft Imagine (DreamSpark) accounts provided by the University.

# Step 2:Create new Resource Group

Next, I created a new resource group to hold all the resources to be created for this web app/database deployment.

![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW9/ref/resourcegroup.png)

# Step 3: Create SQL database in Azure 

After that, I created a blank database along with a server in Azure. 

![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW9/ref/createdatabase.png)

# Step 4: Create Web App

Later, I created a new web app that is to be launched using windows. 

![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW9/ref/webappcreated.png)

# Step 5: Create a server Firewall 

Next, I added a single IP address, and pressed save. 

![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW9/ref/firewallcreated.png)


# Step 6: Connect to Database from SSMS and Load the UP script from HW 8

After connecting the database using my SQL server and admin/password keys I created in Azure, I ran the UP Script from the previous homework. 

![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW9/ref/connecttoserver.png)

![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW9/ref/upscript.png)

![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW9/ref/databaseworking.png)


# Step 7: Publish the Web App 

Next I selected "publish" on my homework 8 solution and chose to push to an existing web app. I did this by selecting my subscription, resource group, and web app I created in the previous steps

![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW9/ref/webappcreated.png)


# Step 8: add the correct Remote Connection String the the Web App Service

In order to be connected to the remote database on Azure, grab the connection string from the SQL Database pane and paste it in the app setting for your app. Make sure to add your credentials to the the connection string, or else it will not work. 

![Alt Text](https://github.com/jazbem24/SeniorProject/blob/master/cs460/HW9/ref/connectionstring.png)

After that, you're finished! 

[Link to Published Website](http://homework8artistry.azurewebsites.net/)


