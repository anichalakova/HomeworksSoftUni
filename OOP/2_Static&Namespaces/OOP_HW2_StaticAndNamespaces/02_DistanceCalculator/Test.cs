using System;
using Point3D = _01_Point3D;

namespace _02_DistanceCalculator
{
    class Test
    {
        static void Main()
        {
            Point3D.Point3D firstPoint = new Point3D.Point3D("A", 3f, 4f, 0f);
            Console.WriteLine(firstPoint.ToString());
            Console.WriteLine("Distance to start: ");
            Console.WriteLine(DistanceCalculator.CalculateDistance(firstPoint, Point3D.Point3D.StartPoint));
            _01_Point3D.Point3D secondPoint = new _01_Point3D.Point3D("B", 0, 0, 0);
            Console.WriteLine(secondPoint.ToString());
            Console.WriteLine("Distance to start: ");
            Console.WriteLine(DistanceCalculator.CalculateDistance(secondPoint, Point3D.Point3D.StartPoint));
        }
    }
}
