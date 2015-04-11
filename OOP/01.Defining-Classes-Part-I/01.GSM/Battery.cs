using System;

class Battery
{

    /// <summary>
    /// Fields of the class Battery
    /// </summary>
    private string model;
    // The ? in double? means that it can be nullable. It is used for the constructors.
    private double? hoursIdle;
    private double? hoursTalk;
    private BatteryType batteryType;

    // Properties. If invalid values are entered, an exception is thrown.

    public string Model
    {
        get { return this.model; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The model of has to be entered!");
            }
            else
            {
                this.model = value;
            }
        }
    }

    public double? HoursIdle
    {
        get { return this.hoursIdle; }
        set
        {
            if (value <= 1)
            {
                throw new ArgumentException("The idle hours should be more than one!");
            }
            else
            {
                this.hoursIdle = value;
            }
        }
    }

    public double? HoursTalk
    {
        get { return this.hoursTalk; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The time talk must be positive!");
            }
            else if (value > this.HoursIdle)
            {
                throw new ArgumentOutOfRangeException("The idle hours must be more than the talk time!");
            }
            else
            {
                this.hoursTalk = value;
            }
        }
    }

    public BatteryType BatteryType
    {
        get { return this.batteryType; }
        set { this.batteryType = value; }
    }


    // The constructors are arranged in kind of a tree. The first constructor takes full number of arguements,
    // the second one inherits the first one and takes only two arguements and the third one inherits the second
    // constructor in the same way.

    /// <summary>
    /// Constructor for the class Battery. The model is mandatory.
    /// </summary>
    /// <param name="model"></param>
    public Battery(string model)
        : this(model, null)
    {
    }

    /// <summary>
    /// Constructor for the class Battery. The model is mandatory.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="hoursIdle"></param>
    public Battery(string model, double? hoursIdle)
        : this(model, hoursIdle, null)
    {
    }

    /// <summary>
    /// Constructor for the class Battery. The model is mandatory.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="hoursIdle"></param>
    /// <param name="hoursTalk"></param>
    public Battery(string model, double? hoursIdle, double? hoursTalk)
        : this(model, hoursIdle, hoursTalk, BatteryType.LiIon)
    {
    }

    /// <summary>
    /// Constructor for the class Battery. The model is mandatory.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="hoursIdle"></param>
    /// <param name="hoursTalk"></param>
    /// <param name="batteryType"></param>
    public Battery(string model, double? hoursIdle, double? hoursTalk, BatteryType batteryType)
    {
        this.Model = model;
        this.HoursIdle = hoursIdle;
        this.HoursTalk = hoursTalk;
        this.BatteryType = batteryType;
    }

    // Overriding ToString() to serve the current class' purpouses.
    public override string ToString()
    {
        return string.Format("Battery model: {0}\nHours idle: {1} h\nTalk time: {2} h\nBattery type: {3}", 
            this.Model, this.HoursIdle, this.HoursTalk, this.BatteryType);
    }
}