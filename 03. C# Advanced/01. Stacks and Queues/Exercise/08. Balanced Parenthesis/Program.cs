using System;
using System.Collections.Generic;

namespace _08.BalancedParentheses
{
    public class BalancedParentheses
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> brackets = new Stack<char>();

            int index = 0;
            bool isBalanced = true;
			
            while (index < input.Length)
            {
                char currentBracket = input[index];
                index++;
				
                if (currentBracket == '{')
                {
                    brackets.Push(currentBracket);
                }
				
                else if (currentBracket == '[')
                {
                    brackets.Push(currentBracket);
                }
				
                else if (currentBracket == '(')
                {
                    brackets.Push(currentBracket);
                }
				
                else
                {
                    if (brackets.Count == 0)
                    {
                        if (currentBracket == '}' || currentBracket == ')' || currentBracket == ')')
                        {
                            isBalanced = false;
                            break;
                        }
                    }

                    char lastBracket = brackets.Peek();

                    if (currentBracket == ')' && lastBracket == '(')
                    {
                        brackets.Pop();
                    }
					
                    else if (currentBracket == '}' && lastBracket == '{')
                    {
                        brackets.Pop();
                    }
					
                    else if (currentBracket == ']' && lastBracket == '[')
                    {
                        brackets.Pop();
                    }
					
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (isBalanced && brackets.Count == 0)
            {
                Console.WriteLine("YES");
            }
			
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}