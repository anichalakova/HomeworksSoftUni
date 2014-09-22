using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Point3D
{
    class DistanceCalculator
    {
        public static float CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            double distance = 0;
            distance = Math.Sqrt(Math.Pow(((double)(firstPoint.Coordinates[0] - secondPoint.Coordinates[0])), 2d)
                + Math.Pow(((double)(firstPoint.Coordinates[1] - secondPoint.Coordinates[1])), 2d)
                + Math.Pow(((double)(firstPoint.Coordinates[2] - secondPoint.Coordinates[2])), 2d));
            return (float)distance;            
        }
    }
}
