namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (parentheses.Length % 2 != 0 ||
                string.IsNullOrEmpty(parentheses))
            {
                return false;
            }

            Stack<char> stack = new Stack<char>(parentheses.Length / 2);

            foreach (var bracket in parentheses)
            {
                char expectedBracket = default;

                switch (bracket)
                {
                    case ')':
                        expectedBracket = '(';
                        break;
                    case ']':
                        expectedBracket = '[';
                        break;
                    case '}':
                        expectedBracket = '{';
                        break;
                    default:
                        stack.Push(bracket);
                        break;
                }

                if (expectedBracket != default && stack.Pop() != expectedBracket)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
