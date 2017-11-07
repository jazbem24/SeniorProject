using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace hw3calc
{
    /// <summary>
    /// implmentation of a singly-linked stack
    /// </summary>

    public class LinkedStack : IStackADT
    {
        private Node top;

        public LinkedStack()
        {
            top = null; //constructing an empty linked stack 
        }

        public void Clear()
        {
            this.top = null; //clears the stack, assigns null to the top element 
        }

        public bool IsEmpty()
        {
            return top == null; //returns top is equal to null (i.e. is empty)
        }

        public object Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("the stack is empty");
            }
            return top.data; //return data of the top element (peekin') 
        }

        public object Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("there's nothing here");
            }
            object topItem = top.data; //sets new variable to the top item's data
            top = top.next; //sets top to the next item in list
            return topItem; // returns the top item 
        }


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
    }
}
