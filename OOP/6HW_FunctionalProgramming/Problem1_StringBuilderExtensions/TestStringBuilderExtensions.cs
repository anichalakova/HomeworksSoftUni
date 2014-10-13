using System;
using System.Text;

namespace Problem1_StringBuilderExtensions
{
    class TestStringBuilderExtensions
    {
        static void Main()
        {
            StringBuilder testString1 = new StringBuilder("012345678");            
            Console.WriteLine(testString1.Substring(3, 2));            

            StringBuilder teststring2 = new StringBuilder("This is some test string to see if my extension methods work.");
            Console.WriteLine(teststring2.RemoveText("Extension"));

            StringBuilder testString3 = new StringBuilder("Firstpart and ");
            testString3.AppendAll<string>("secondpart");
            Console.WriteLine(testString3);
            
            testString3.AppendAll<Array>(new int[] {1, 2, 3});
            Console.WriteLine(testString3);
        }
    }
}
