using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hw10.Tree
{
    public class ToPostfix
    {
        public static string ConvertToPostFix(string input)
        {
            StringBuilder postFix = new StringBuilder();
            string arrival;
            var pre = String.Concat(input.Where(c => !Char.IsWhiteSpace(c)));
            var inf = string.Join(" ", pre.ToCharArray());
            var inFix = inf.Split(' ');
            Stack<string> operators = new Stack<string>(); //Creates a new Stack
            foreach (string c in inFix) //Iterates characters in inFix
            {
                if (!"()+-*/%".Contains(c))
                    postFix.Append(c + " ");
                else if (c == "(")
                    operators.Push(c);
                else if (c == ")") //Removes all previous elements from Stack and puts them in 
                    //front of PostFix.  
                {
                    arrival = operators.Pop();
                    while (arrival != "(")
                    {
                        postFix.Append(arrival + " ");
                        arrival = operators.Pop();
                    }
                }
                else
                {
                    if (operators.Count != 0 && Predecessor(operators.Peek(), c)) //If find an operator
                    {
                        arrival = operators.Pop();
                        while (Predecessor(arrival, c))
                        {
                            postFix.Append(arrival + " ");

                            if (operators.Count == 0)
                                break;

                            arrival = operators.Pop();
                        }

                        operators.Push(c);
                    }
                    else
                        operators.Push(c); //If Stack is empty or the operator has precedence 
                }
            }

            while (operators.Count > 0)
            {
                arrival = operators.Pop();
                postFix.Append(arrival + " ");
            }

            return postFix.ToString();
        }
        
        static bool Predecessor(string firstOperator, string secondOperator)
        {
            string opString = "(+-*/%";

            int firstPoint, secondPoint;

            int[] precedence = {0, 12, 12, 13, 13, 13}; // "(" has less prececence

            firstPoint = opString.IndexOf(firstOperator);
            secondPoint = opString.IndexOf(secondOperator);

            return (precedence[firstPoint] >= precedence[secondPoint]) ? true : false;
        }
    }
}