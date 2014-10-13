using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingThings
{
    class Program
    {
        static void Main()
        {
            int[] firstArray = { 1, 2, -5, 90 };
            int[] secondArray = { 33, 33, 44, 55 };

            var result = firstArray.Concat(firstArray);

            Console.WriteLine(String.Join(", ", result));
        }
    }
}
