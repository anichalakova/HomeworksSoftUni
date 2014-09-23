using System;

namespace _01_Point3D
{
    class Test
    {
        static void Main()
        {
            Point3D firstPoint = new Point3D("A", 2f, 7f, 5.45f );
            Console.WriteLine(firstPoint.ToString());                        
            Point3D secondPoint = new Point3D("B", 0, 0, 3.1489f);
            Console.WriteLine(secondPoint.ToString());
            Console.WriteLine(Point3D.StartPoint.ToString());            
        }
    }
}