using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Net;

namespace hw3calc
{
    class Calculator
    {
        //creating an empty stack 
        private IStackADT calcStack = new LinkedStack();


        //main entry point for the calcultor 
        public static void Main(string[] args)
        {
            Calculator app = new Calculator();
            bool playAgain = true;
            Console.WriteLine("Postfix Calculator.Recognizes these operators: +-* /");
            while (playAgain)
            {
                playAgain = app.doCalculation();
            }
            Console.WriteLine("Bye");


        }

        private bool doCalculation()
        {
            Console.WriteLine("Please enter q to quit\n");

            string input = "2 2 +";
            Console.WriteLine("> "); //prompt user

            input = (Console.ReadLine());

            //see if user wishes to quit 
            if (input.StartsWith("q") || input.StartsWith("Q"))
            {
                return false;
            }

            //otherwise, start calculatin', and if not enough operands, throws exception
            string output = "4";
            try
            {
                output = evaluatePostFixInput(input);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Input Error: " + input + " is not an allowed number or operator");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n\t >>> " + input + " = " + output);
            return true;
        }

        /// <summary>
        /// Evaluates an artimetic expression written in postfix form 
        /// </summary>
        /// <returns>The post fix input.</returns>
        /// <param name="input">Input.</param>
        public string evaluatePostFixInput(string input)
        {
            if (input == null || input.Equals(""))
                throw new ArgumentException();
            //clear the stack before using it; 

            calcStack.Clear();

            string s; //temp variable for token real
            double a; //temp variable for operand
            double b; //... for operand
            double c; //... for answer; 
            double num; //number holder for parsed input 

            //creating a string array to parse 
            //split using a white space 
            // used https://msdn.microsoft.com/en-us/library/994c0zb1(v=vs.110).aspx for ref 

            string[] inputArray = input.Split(' ');

            foreach (string element in inputArray)
            {
                if (Double.TryParse(element, out num))
                {
                    calcStack.Push(Convert.ToDouble(element));
                }
                else
                {
                    //must be an operator or some other character or word 
                    s = element;
                    if (s.Length > 1)
                        throw new ArgumentException("Input Error: " + s + " is not an allowed number or operator. Or didn't place space between operands ");

                    if (calcStack.IsEmpty())
                    {
                        throw new ArgumentException("Improper input format. Stack became empty when expecting second operand.");
                    }
                    b = (Convert.ToDouble(calcStack.Pop()));
                    //convert so they don't fail 

                    if (calcStack.IsEmpty())
                    {
                        throw new ArgumentException("Improper input format. Stack became empty when expecting first operand");
                    }
                    a = (Convert.ToDouble(calcStack.Pop()));
                    c = doOperation(a, b, s);
                    calcStack.Push(Convert.ToDouble(c));
                }

            }
            return Convert.ToString(calcStack.Pop());
        }
        /// <summary>
        /// Performs the arithmetic
        /// </summary>
        /// <returns>a double (answer)</returns>
        /// <param name="a">operand 1 .</param>
        /// <param name="b">operand 2.</param>
        /// <param name="s">input</param>
        public double doOperation(double a, double b, string s)
        {
            double c = 0.0;
            if (s.Equals("+"))
                c = (a + b);
            else if (s.Equals("-"))
                c = (a - b);
            else if (s.Equals("*"))
                c = (a * b);
            else if (s.Equals("/"))
            {
                try
                {
                    c = (a / b);
                    if (c == double.NegativeInfinity || c == double.PositiveInfinity)
                        throw new ArgumentException("Can't divide by 0");
                }
                catch (ArithmeticException e)
                {
                    throw new ArgumentException(e.Message);
                }

            }
            else
                throw new ArgumentException();
            return c;
        }
    }
}