namespace ProjectParse.Utilities
{
    public static class ParseUtils
    {
        /// <summary>
        /// Removes all leading white space from a string and returns the result.
        /// </summary>
        public static string RemoveLeadingWhiteSpace(string text)
        {
            int start = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsWhiteSpace(text[i]))
                {
                    break;
                }
                start++;
            }
            if (start > 0)
            {
                return text.Substring(start);
            }
            return text;
        }

        public static string GetVariableValue(string text)
        {
            int start = 0;
            int length = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (c == '=')
                {
                    // Remove white space 
                    while (char.IsWhiteSpace(c))
                    {
                        i++;
                        c = text[i];
                    }
                    // We are out of white space so we start parsing
                    start = i;
                    length = 0;
                    while (!char.IsWhiteSpace(c) && i < text.Length)
                    {
                        i++;
                        length++;
                    }

                    if (length > 0)
                    {
                        return text.Substring(start, length);
                    }
                }
            }
            return string.Empty;
        }
    }
}