using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace hw3calc
/// <summary>
/// Linked stack Interface to be able to implement one for the postfix calculator 
/// used chapter 13 on creating interfaces in C# 3.0 as a resource 
/// </summary>
{

    public interface IStackADT
    {
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

    }
}