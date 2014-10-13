using System;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Problem2_LINQExtensionMethods
{
    public static class LINQ_ExtensionMethods
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {            
            var filteredCollection =
                collection.Where(item => !predicate(item));

            return filteredCollection;                     
        } 

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            var result = collection;

            for (int i = 0; i < count - 1; i++)
            {
                result = result.Concat(collection);   
            }     

            return result;
        }
    }
}
