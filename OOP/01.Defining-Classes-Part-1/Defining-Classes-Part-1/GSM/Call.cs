namespace GSM
{
    using System;

    public class Call
    {
        #region Fields
        private DateTime date;
        private string time;
        private string dialedPhone;
        private uint duration;
        #endregion

        #region Properties
        // The setters in the properties are private based on the assumption that they are immediately set after placing the call, i.e. defining a new object Call using the constructor.

        /// <summary>
        /// Date of the phone call. For simplification is taken the current date.
        /// </summary>
        public DateTime Date
        {
            get
            {
                return this.date;
            }
            private set
            {
                this.date = value;
            }
        }

        /// <summary>
        /// Time of the day when the phone call is placed. For simplification is taken the current time.
        /// </summary>
        public string Time
        {
            get
            {
                return this.time;
            }
            private set
            {
                this.time = value;
            }
        }

        /// <summary>
        /// Dialed phone number.
        /// </summary>
        public string DialedPhone
        {
            get
            {
                return this.dialedPhone;
            }
            private set
            {
                this.dialedPhone = value;
            }
        }

        /// <summary>
        /// Duration of the call.
        /// </summary>
        public uint Duration
        {
            get
            {
                return this.duration;
            }
            private set
            {
                this.duration = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a call.
        /// </summary>
        /// <param name="inputDialedPhone">Dialed phone number. Can be in any given format.</param>
        /// <param name="inputDuration">Duration of the phone call in seconds.</param>
        public Call(string inputDialedPhone, uint inputDuration)
        {
            this.Date = DateTime.Now;
            this.Time = string.Format("{0}:{1}:{2}", date.Hour, date.Minute, date.Second);
            this.DialedPhone = inputDialedPhone;
            this.Duration = inputDuration;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Displays information about the call.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Date of call: {0}\nTime of call: {1}\nDialed phone number: {2}\nCall duration: {3}", this.Date.ToString("dd/MM/yyyy"), this.Time, this.DialedPhone, this.Duration);
        }
        #endregion
    }
}
