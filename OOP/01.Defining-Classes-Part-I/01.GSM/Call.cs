
class Call
{
    private readonly System.DateTime date;
    private readonly string time;
    private readonly string dialedPhoneNumber;
    private readonly uint duration;

    public Call(string dialedPhoneNumber, uint duration)
    {
        System.DateTime date = System.DateTime.Now;
        string time = string.Format("{0}:{1}:{2}", date.Hour, date.Minute, date.Second);
        this.date = date;
        this.time = time;
        this.duration = duration;
        this.dialedPhoneNumber = dialedPhoneNumber;
    }

    public System.DateTime Date
    {
        get
        {
            return this.date;
        }
    }

    public string Time
    {
        get
        {
            return this.time;
        }
    }

    public string DialedPhoneNumber
    {
        get
        {
            return this.dialedPhoneNumber;
        }
    }

    public uint Duration
    {
        get
        {
            return this.duration;
        }
    }

    public override string ToString()
    {
        return string.Format("Call log:\nDate: {0}\nTime: {1}\nDialed phone: {2}\nCall duration: {3}"
            ,this.Date,this.Time,this.DialedPhoneNumber,this.Duration);
    }
}
