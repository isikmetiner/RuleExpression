using System.Collections.Generic;

namespace RuleExpression
{
    public static class Operation
    {
        public static bool Calculate(string expression, int expectedValue)
        {
            Stack<int> values = new Stack<int>();
            Stack<char> operators = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsDigit(expression[i]))
                {
                    int num = 0;
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        num = num * 10 + (expression[i] - '0');
                        i++;
                    }

                    i--;

                    values.Push(num);
                }
                else if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
                {
                    while (operators.Count > 0 && HasPrecedence(expression[i], operators.Peek()))
                    {
                        values.Push(ApplyOperation(operators.Pop(), values.Pop(), values.Pop()));
                    }

                    operators.Push(expression[i]);
                }
                else if (expression[i] == '(')
                {
                    operators.Push(expression[i]);
                }
                else if (expression[i] == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        values.Push(ApplyOperation(operators.Pop(), values.Pop(), values.Pop()));
                    }

                    operators.Pop();
                }
            }

            while (operators.Count > 0)
            {
                values.Push(ApplyOperation(operators.Pop(), values.Pop(), values.Pop()));
            }

            int result = values.Pop();

            return result == expectedValue;
        }

        private static bool HasPrecedence(char operatorFirst, char operatorSecond)
        {
            if (operatorSecond == '(' || operatorSecond == ')')
            {
                return false;
            }
            if ((operatorFirst == '*' || operatorFirst == '/') && (operatorSecond == '+' || operatorSecond == '-'))
            {
                return false;
            }
            return true;
        }

        private static int ApplyOperation(char op, int b, int a)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
            }
            return 0;
        }
    }
}