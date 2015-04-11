namespace Points
{
    using System.Text;
    using System.Collections.Generic;

    public class Path
    {
        private List<Point3D> points;

        public Path()
        {
            points = new List<Point3D>();
        }

        public List<Point3D> Points
        {
            get
            {
                return this.points;
            }
            set
            {
                this.points = value;
            }
        }

        public void AddPoint(Point3D inputPoint)
        {
            this.Points.Add(inputPoint);
        }

        public string PrintPath()
        {
            StringBuilder stringPath = new StringBuilder();

            for (int i = 0; i < this.Points.Count; i++)
            {
                stringPath.Append(this.Points[i]);
                stringPath.Append("\n");
            }

            return stringPath.ToString();
        }
    }
}
