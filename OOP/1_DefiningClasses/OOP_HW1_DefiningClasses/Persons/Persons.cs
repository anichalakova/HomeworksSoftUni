using System;

namespace Persons
{
    class Persons
    {
        static void Main()
        {
            Person p1 = new Person("", 32);
            Console.WriteLine(p1.ToString());
            Console.WriteLine();
            Person p2 = new Person("Me", 32, "my-email@gmail.com");
            Console.WriteLine(p2.ToString());
        }
    }
}
