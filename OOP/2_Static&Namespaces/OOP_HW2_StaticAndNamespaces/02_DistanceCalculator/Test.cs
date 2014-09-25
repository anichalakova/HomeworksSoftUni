using System;
using Point3D = _01_Point3D;
using _01_Point3D;

namespace _02_DistanceCalculator
{
    class Test
    {
        static void Main()
        {
            Point firstPoint = new Point("A", 3f, 4f, 0f);
            Console.WriteLine(firstPoint.ToString());
            Console.WriteLine("Distance to start: ");
            Console.WriteLine(DistanceCalculator.CalculateDistance(firstPoint, Point.StartPoint));
            Point secondPoint = new Point("B", 0, 0, 0);
            Console.WriteLine(secondPoint.ToString());
            Console.WriteLine("Distance to start: ");
            Console.WriteLine(DistanceCalculator.CalculateDistance(secondPoint, Point.StartPoint));
        }
    }
}
