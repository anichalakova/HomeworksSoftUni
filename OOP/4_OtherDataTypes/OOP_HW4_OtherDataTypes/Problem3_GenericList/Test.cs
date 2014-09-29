using System;

namespace Problem3_GenericList
{
    class Test
    {
        static void Main()
        {
            Type type = typeof(GenericList<int>);
            object[] attributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attr in attributes)
            {
                Console.WriteLine("Version: "+ attr.Version);
            }

            GenericList<int> testInt = new GenericList<int>(5);
            testInt.Add(1);            
            Console.WriteLine("Adding: " + testInt);

            testInt.Insert(3, 8);
            Console.WriteLine("Inserting at given position: " + testInt);
                        
            for (int i = testInt.Count; i < 7; i++)
            {
                testInt.Add(i+1);
            }
            Console.WriteLine("Doubling the capacity: " + testInt);

            int intAtIndex = testInt.Get(4);
            Console.WriteLine("Getting element at given position: "+ intAtIndex);

            testInt.Remove(4);
            Console.WriteLine("Removing element at given position: " + testInt);

            Console.WriteLine("Checking if the list contains a value and returning the index of it: " + testInt.SearchValue(6));

            Console.WriteLine("Min: " + testInt.Min());

            Console.WriteLine("Max: " + testInt.Max());

            testInt.Clear();
            Console.WriteLine("Clearing the list: " + testInt);            

            GenericList<string> testString = new GenericList<string>(6);
            testString.Add("Let's");
            testString.Add("test");
            testString.Add("");
            testString.Add("a");
            Console.WriteLine(testString);
            string stringAtIndex = testString.Get(1);
            Console.WriteLine(stringAtIndex);            
            testString.Clear();
            Console.WriteLine(testString);
        }
    }
}
