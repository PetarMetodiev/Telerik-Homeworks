using System;
using System.Collections.Generic;

class GSM
{
    /// <summary>
    /// Fields for the class GSM.
    /// </summary>
    private string model;
    private string manifacurer;
    private decimal? price;
    private string owner;
    private Battery battery;
    private Display display;
    private List<Call> callLog = new List<Call>();
    private static GSM iPhone = new GSM("iPhone4s", "Apple", 999, "Steve Jobs", new Battery("Apple", 100, 20, BatteryType.LiIon), new Display(3.7, "16M"));

    // Properties. If invalid data is entered, an exception is thrown.

    public string Model
    {
        get { return this.model; }
        set
        {
            if (value == string.Empty)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.model = value;
            }
        }
    }

    public string Manifacturer
    {
        get { return this.manifacurer; }
        set
        {
            if (value == string.Empty)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.manifacurer = value;
            }
        }
    }

    public decimal? Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("The price of the GSM has to be positive!");
            }
            else
            {
                this.price = value;
            }
        }
    }

    public string Owner
    {
        get { return this.owner; }
        set
        {
            if (value == string.Empty)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.owner = value;
            }
        }
    }

    public Battery Battery
    {
        get
        {
            return this.battery;
        }
        set
        {
            this.battery = value;
        }
    }

    public Display Display
    {
        get
        {
            return this.display;
        }
        set
        {
            this.display = value;
        }
    }

    public static GSM IPhone
    {
        get
        {
            return iPhone;
        }
    }

    public List<Call> CallLog
    {
        get
        {
            return this.callLog;
        }
    }

    // Constructors follow the same logic as in the battery and display.

    /// <summary>
    /// Constructor for the calss GSM. The model and manifaturer are mandatory.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="manifacturer"></param>
    public GSM(string model, string manifacturer)
        : this(model, manifacturer, null)
    {
    }

    /// <summary>
    /// Constructor for the calss GSM. The model and manifaturer are mandatory.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="manifacturer"></param>
    /// <param name="price"></param>
    public GSM(string model, string manifacturer, decimal? price)
        : this(model, manifacturer, price, null)
    {
    }

    /// <summary>
    /// Constructor for the calss GSM. The model and manifaturer are mandatory.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="manifacturer"></param>
    /// <param name="price"></param>
    public GSM(string model, string manifacturer, decimal? price, string owner)
        : this(model, manifacturer, price, owner, null, null)
    {
    }

    public GSM(string model, string manifacturer, decimal? price, string owner, Battery battery, Display display)
    {
        this.Model = model;
        this.Manifacturer = manifacturer;
        this.Price = price;
        this.Owner = owner;
        this.Battery = battery;
        this.Display = display;
    }

    public void AddCall(string dialedNumber, uint duration)
    {
        Call newCall = new Call(dialedNumber, duration);
        this.callLog.Add(newCall);
    }

    public void DeleteCall(int index)
    {
        if (index < this.callLog.Count && index > -1)
        {
            this.callLog.RemoveAt(index);
        }
        else
        {
            throw new ArgumentException("The required call is not in the list.");
        }
    }

    public void ClearCallHistory()
    {
        this.callLog.Clear();
    }

    public decimal CallPrice(decimal price)
    {
        uint minutes = 0;
        uint remainder = 0;

        for (int i = 0; i < this.callLog.Count; i++)
        {
            minutes += callLog[i].Duration / 60;
            remainder = callLog[i].Duration % 60;

            if (remainder != 0)
            {
                minutes++;
            }
        }

        return minutes * price;
    }

    public override string ToString()
    {
        return string.Format("GSM model: {0}\nGSM manifacturer: {1}\nGSM price: {2}\nGSM owner: {3}\n{4}\n{5}",
            this.model, this.manifacurer, this.price, this.owner, this.battery, this.display);
    }
}
