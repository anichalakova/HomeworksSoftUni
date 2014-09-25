using System;

namespace _02_DistanceCalculator
{
    class DistanceCalculator
    {
        public static float CalculateDistance(_01_Point3D.Point firstPoint, _01_Point3D.Point secondPoint)
        {
            double distance = 0;
            distance = Math.Sqrt(Math.Pow(((double)(firstPoint.Coordinates[0] - secondPoint.Coordinates[0])), 2d)
                + Math.Pow(((double)(firstPoint.Coordinates[1] - secondPoint.Coordinates[1])), 2d)
                + Math.Pow(((double)(firstPoint.Coordinates[2] - secondPoint.Coordinates[2])), 2d));
            return (float)distance;
        }
    }
}
