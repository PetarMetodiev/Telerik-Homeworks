namespace Points
{
    public struct Point3D
    {
        private static readonly Point3D origin = new Point3D(0,0,0);

        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public static Point3D Origin
        {
            get
            {
                return origin;
            }
        }

        public Point3D(decimal inputX, decimal inputY, decimal inputZ)
            : this()    // Structure has to have a parameterless constructor.
        {
            this.X = inputX;
            this.Y = inputY;
            this.Z = inputZ;
        }

        public override string ToString()
        {
            return string.Format("{{{0}; {1}; {2}}}", this.X, this.Y, this.Z);
        }

    }
}
