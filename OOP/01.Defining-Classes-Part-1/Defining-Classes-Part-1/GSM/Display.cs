namespace GSM
{
    using System;

    public class Display
    {
        #region Fields
        private double? size;
        private uint? colors;
        #endregion

        #region Properties
        /// <summary>
        /// Sets the size of the display. If invalid data is entered an exception is thrown.
        /// </summary>
        public double? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value < 2 || value > 6.5)
                {
                    throw new ArgumentOutOfRangeException("The display size is either too big or too small!");
                }
                else
                {
                    this.size = value;
                }
            }
        }

        /// <summary>
        /// Sets the display colors.
        /// </summary>
        public uint? Colors
        {
            get
            {
                return this.colors;
            }
            set
            {
                this.colors = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new display.
        /// </summary>
        public Display()
            : this(null)
        {
        }

        /// <summary>
        /// Creates a new display.
        /// </summary>
        /// <param name="inputSize">Size of the display.</param>
        public Display(double? inputSize)
            : this(inputSize, null)
        {
        }

        /// <summary>
        /// Creates a new display.
        /// </summary>
        /// <param name="inputSize">Size of the display.</param>
        /// <param name="inputColors">Number of colors of the display.</param>
        public Display(double? inputSize, uint? inputColors)
        {
            this.Size = inputSize;
            this.Colors = inputColors;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Displays the information about the display.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Display size: {0}\nDisplay colors: {1}", this.Size, this.Colors);
        }
        #endregion
    }
}
