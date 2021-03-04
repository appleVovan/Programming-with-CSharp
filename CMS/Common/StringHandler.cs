using System;
using System.Text;

namespace AR.ProgrammingWithCSharp.CMS.Common
{
    public static class StringHandler
    {
        public static string InsertSpaces(this string source)
        {
            var result = new StringBuilder();
            if (!String.IsNullOrWhiteSpace(source))
            {
                foreach(var letter in source)
                {
                    if (Char.IsUpper(letter))
                    {
                        if (result.Length > 0 && result[result.Length - 1]!=' ')
                        {
                            result.Append(' ');
                        }
                    }
                    result.Append(letter);
                }
            }
            return result.ToString();            
        }
    }
}
