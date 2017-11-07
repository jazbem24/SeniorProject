# Homework 3

The goal of this homework was the gain an greater understanding for C# by translating a postfix calculator written in java to C# 

# Step 1

To start, I compiled and ran the javacode from the command line on my machine to see exactly what it does. I used the commands: 

```
cd desktop
javac calculator.java
java calculator 
```

![Wireframe]()

# Step 2 - IStackADT interface

Next, I created the the IStackADT interface in C#. In C#, interfaces typically start with I to differentiate from other types of files. I also created XML to comment the code and get a greater understanding for what was happening in the code. 

```
 /// <summary>
        /// methods to allow one to push onto the stack, 
        /// push off the stack,
        /// peek to see the top of stack(but no removal),
        /// see if the stack is empty,
        /// and clear the stack
        /// </summary>

        object Push(object var1); /// method to push item onto the top of the stack
        object Pop(); ///method to remove and return the item on the top of the stack
        object Peek();///method to return the top item but does not remove
        bool IsEmpty(); ///method to see if the stack is empty or not
        void Clear();///empty the stack 

```

# Step 3 - Node Class

After creating the IStackADT interface, I made a Node.cs file. This allowed me to start working with the getters and setters in C#, which I think are pretty slick. 

```
public object Data
        {
            set { data = value; }
            get { return data; }
        }
```

# Step 4 - Implementing the Linked Stack

Now that the Node class and interface were ready, it was time to create an implementation for the linked stack. Here's an example of the implementation of pushing onto the stack: 

```
 public object Push(object item)
        {
            if (item == null)
            {
                throw new Exception("this element is empty");
            }
            Node newItem = new Node(item, top); //creates new node with data from the item and reference to next node 
            top = newItem; // top of the stack in now the newest item

            return item; //returns reference to the item removed 
        }
```

# Step 5 - The Main Calculator Class

Up to this point, there weren't too many differences between java and C#. A main difference though is that C# doesn't really have a Scanner like in Java. I worked around this by splitting an array of the input that came in. 

```
string[] inputArray = input.Split(' ');

            foreach (string element in inputArray)
            {
                if (Double.TryParse(element, out num))
                {
                    calcStack.Push(Convert.ToDouble(element));
                }
```

# Step 6 - Now to see it at work 

![Wireframe]()