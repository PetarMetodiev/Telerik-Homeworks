namespace Points
{
    using System;
    using System.Collections.Generic;

    class PointsMain
    {
        static void Main()
        {
            // Test of task 3.
            var newPoint = new Point3D(6.3M,5M,-8.3M);
            Console.WriteLine(Point3D.Origin);
            Console.WriteLine("Distance between point {0} and point {1}: {2:F3}",Point3D.Origin, newPoint, PointsDistance.CaculateDistance(Point3D.Origin,newPoint));

            // Test of task 4.
            var pointList = new Path();
            pointList.AddPoint(new Point3D(2M, 0M, 3.2M));
            pointList.AddPoint(new Point3D(-9M, 0.2M, 3.2M));
            pointList.AddPoint(new Point3D(-3M, -9.10M, 7.2M));
            pointList.AddPoint(new Point3D(0.002M, 0.009M, 0.0002M));
            pointList.AddPoint(new Point3D(6M, 8M, 10M));
            pointList.AddPoint(new Point3D(3M, 2M, 999M));

            PathStorage.SaveToFile(pointList, "Points");
            Console.WriteLine("Path saved to file");

            Path loadedPath = PathStorage.LoadFromFile("Points");
            Console.WriteLine("Path loaded from file");
            Console.WriteLine(loadedPath.PrintPath());
            // Just to test if everything is ok.
            PathStorage.SaveToFile(loadedPath, "Proba");
        }
    }
}
