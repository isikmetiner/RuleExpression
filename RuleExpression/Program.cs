using System;

namespace RuleExpression
{
    class Program
    {
        public static void Main(string[] args)
        {
            string expression = "((8+4)/2)+(25*2/2-1)";
            

            if (!Validation.IsParenthesesValid(expression))
            {
                Console.WriteLine("Parantezlerde sorun var, duzelt tekrar dene");
            }

            int result = Operation.Calculate(expression);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}