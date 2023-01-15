namespace RuleExpression
{
    public static class Validation
    {
        public static bool IsParenthesesValid(string input)
        {
            string queue = "";

            char[] inputChars = input.ToCharArray();

            for (int i = 0; i < inputChars.Length; i++)
            {
                switch (inputChars[i])
                {
                    case '(':
                        queue = string.Concat(inputChars[i], queue);
                        break;
                    case ')':
                        if (!queue.StartsWith("("))
                            return false;
                        else
                            queue = queue.Remove(0, 1);
                        break;
                }
            }

            if (queue.Length > 0)
                return false;
            else
                return true;
        }
    }
}