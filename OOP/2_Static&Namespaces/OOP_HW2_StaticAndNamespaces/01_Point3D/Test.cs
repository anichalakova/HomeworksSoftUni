using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Point3D
{
    class Test
    {
        static void Main()
        {
            Point3D firstPoint = new Point3D("A", 2f, 7f, 5.45f );
            Console.WriteLine(firstPoint.ToString());
            Console.Write("Distance to center:");
            Console.WriteLine(DistanceCalculator.CalculateDistance(firstPoint, Point3D.StartPoint));
            Point3D secondPoint = new Point3D("B", 0, 0, 3.1489f);
            Console.WriteLine(secondPoint.ToString());
            Console.Write("Distance to center:");
            Console.WriteLine(DistanceCalculator.CalculateDistance(secondPoint, Point3D.StartPoint));
        }
    }
}