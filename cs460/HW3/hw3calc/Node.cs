using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3calc
/// <summary>
///singly linked node class. Use of generics for the data,
/// Node to reference the next Node in the chain 
/// </summary>

{
    public class Node<T>
    {
        public T data; //payload
        public Node<T> next; //reference to next Node in chain

        /// <summary>
        /// Gets or sets the data for the payload (cannot set it to null like in Java before Generics) 
        /// </summary>
        public T Data
        {
            set { data = value; }
            get { return data; }
        }

        /// <summary>
        /// Gets or sets the data for the next Node (cannot set it to null like in Java before Generics)
        /// </summary>
        public Node<T> Next
        {
            set { next = value; }
            get { return next; }
        }

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }



}
