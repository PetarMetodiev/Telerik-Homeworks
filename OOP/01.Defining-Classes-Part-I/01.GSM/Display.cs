using System;

class Display
{

    /// <summary>
    /// Fields of the class Display.
    /// </summary>
    private double? size;
    private string colors;

    // Properties. If invalid data is entered, an exception is thrown.

    public double? Size
    {
        get { return this.size; }
        set
        {
            if (value < 2 || value > 6.5)
            {
                throw new ArgumentOutOfRangeException("The display size is either too small or too big!");
            }
            else
            {
                this.size = value;
            }
        }
    }

    public string Colors
    {
        get { return this.colors; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The display colors must be entered!");
            }
            else
            {
                this.colors = value;
            }
        }
    }

    // The logic with the constructors for the display is the same as the one for the battery.

    public Display()
        : this(2)
    {
    }

    public Display(double? size)
        : this(size, "Unknown")
    {
    }

    public Display(double? size, string colors)
    {
        this.Size = size;
        this.Colors = colors;
    }

    // Overriding ToString() to serve the current class' purpouses.
    public override string ToString()
    {
        return string.Format("Display size: {0}\"\nNumber of colors: {1}", this.Size, this.Colors);
    }
}