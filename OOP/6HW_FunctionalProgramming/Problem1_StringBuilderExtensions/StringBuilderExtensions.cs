using System;
using System.Text;
using System.Collections;

namespace Problem1_StringBuilderExtensions
{
    public static class StringBuilderExtensions
    {
        // Returns a substring by given start index and length
        public static StringBuilder Substring(this StringBuilder str, int startIndex, int length)
        {
            str = str.Remove(0, startIndex);
            str = str.Remove(length, str.Length - length);
            return str;
        }

        //Removes given text (case insensitive) from the string. 
        public static StringBuilder RemoveText(this StringBuilder str, string textToRemove)
        {
            string strCaseInsensitive = str.ToString().ToLower();
            int index = strCaseInsensitive.IndexOf(textToRemove.ToLower());
            str = str.Remove(index, textToRemove.Length);
            return str;
        }

        // Appends the string representations of all items from the specified collection. 
        public static StringBuilder AppendAll<T>(this StringBuilder str, IEnumerable collection)
        {
            foreach (var item in collection)
            {
                str.Append(item.ToString());
            }            
            return str;
        }
    }
}
