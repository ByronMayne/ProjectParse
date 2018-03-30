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
    }
}