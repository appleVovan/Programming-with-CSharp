using System;

namespace AR.ProgrammingWithCSharp.CMS.Common
{
    public static class StringHandler
    {
        public static string InsertSpaces(this string source)
        {
            var result = "";
            if (!String.IsNullOrWhiteSpace(source))
            {
                foreach(var letter in source)
                {
                    if (Char.IsUpper(letter))
                    {
                        if (!String.IsNullOrWhiteSpace(result) && result[result.Length - 1]!=' ')
                        {
                            result += " ";
                        }
                    }
                    result += letter;
                }
            }
            return result;            
        }
    }
}
