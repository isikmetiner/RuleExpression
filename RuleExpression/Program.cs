using System;

namespace RuleExpression
{
    class Program
    {
        public static void Main(string[] args)
        {
            string expression = "(8+4)/2";

            if (!Validation.IsParenthesesValid(expression))
            {
                Console.WriteLine("Parantezlerde sorun var, duzelt tekrar dene");
            }

            bool result = Operation.Calculate(expression, 6);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}