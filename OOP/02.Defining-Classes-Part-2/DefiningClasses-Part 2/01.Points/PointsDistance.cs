namespace Points
{
    using System;

    public static class PointsDistance
    {
        public static double CaculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            // Splitting the code into easier to comprehend pieces.
            decimal firstMember = (secondPoint.X - firstPoint.X) * (secondPoint.X - firstPoint.X);
            decimal secondtMember = (secondPoint.Y - firstPoint.Y) * (secondPoint.Y - firstPoint.Y);
            decimal thirdMember = (secondPoint.Z - firstPoint.Z) * (secondPoint.Z - firstPoint.Z);

            double distance = Math.Sqrt((double)firstMember + (double)secondtMember + (double)thirdMember);

            return distance;
        }
    }
}
