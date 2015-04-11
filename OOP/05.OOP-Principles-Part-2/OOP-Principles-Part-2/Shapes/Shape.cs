namespace Shapes
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;

        protected double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("Width must be positive!");
                }
                this.width = value;
            }
        }

        protected double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("Height must be positive!");
                }
                this.height = value;
            }
        }

        public Shape(double inputHeight, double inputWidth)
        {
            this.Height = inputHeight;
            this.Width = inputWidth;
        }

        public abstract double CalculateSurface();
    }
}
