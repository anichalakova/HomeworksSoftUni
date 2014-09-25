using System;

namespace _01_Point3D
{
    class Test
    {
        static void Main()
        {
            Point firstPoint = new Point("A", 2f, 7f, 5.45f );
            Console.WriteLine(firstPoint.ToString());                        
            Point secondPoint = new Point("B", 0, 0, 3.1489f);
            Console.WriteLine(secondPoint.ToString());
            Console.WriteLine(Point.StartPoint.ToString());            
        }
    }
}