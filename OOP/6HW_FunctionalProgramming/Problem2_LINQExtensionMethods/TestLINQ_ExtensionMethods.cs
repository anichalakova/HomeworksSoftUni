using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace Problem2_LINQExtensionMethods
{
    class TestLINQ_ExtensionMethods
    {
        static void Main()
        {
            string[] testCollection1 = {"Sofia", "Varna", "Pleven", "Ruse", "", "" };
            Func<string, bool> isEmptyOrNull = string.IsNullOrEmpty;

           

            var results = testCollection1.WhereNot(isEmptyOrNull);
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            



            int[] testCollection2 = {1, -2, 16, 5, 19};
            Func<int, bool> isBiggerThan10 = delegate(int number)
            {
                return number > 10;
            };

            Func<int, bool> isNegative = ((num) =>
                {
                    return num < 0;
                });
            
            var results2 = testCollection2.WhereNot(isBiggerThan10);
            Console.WriteLine(String.Join(", ", results2));

            var results3 = testCollection2.WhereNot(isNegative);
            Console.WriteLine(String.Join(", ", results3));

            var results4 = testCollection2.Repeat<int>(3);
            Console.WriteLine(String.Join(", ", results4));
        }
    }
}
