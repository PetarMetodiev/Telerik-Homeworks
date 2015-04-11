namespace GSM
{
    using System;
    using System.Collections.Generic;

    public class GSM
    {
        #region Fields
        private string model;       // Mandatory
        private string manifacturer;        // Mandatory
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>();
        private static GSM iPhone = new GSM("iPhone 4S", "Apple", 1999, "Steve Jobs", new Battery("Kitaiska", 12, 1.5, BatteryType.LiIon), new Display(3.5, 16000000));
        #endregion

        #region Properties
        /// <summary>
        /// Model of the GSM. If invalid data is entered an exception is thrown.
        /// </summary>
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value == string.Empty || value == null)
                {
                    throw new ArgumentNullException("The model has to be entered!");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        /// <summary>
        /// Manifacturer of the GSM. If invalid data is entered an exception is thrown.
        /// </summary>
        public string Manifacturer
        {
            get
            {
                return this.manifacturer;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("The manifacturer has to be entered!");
                }
                else
                {
                    this.manifacturer = value;
                }
            }
        }

        /// <summary>
        /// Price of the GSM. If invalid data is entered an exception is thrown.
        /// </summary>
        public decimal? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The price has to be positive!");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        /// <summary>
        /// Owner of the GSM. If invalid data is entered an exception is thrown.
        /// </summary>
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        /// <summary>
        /// Battery of the GSM.
        /// </summary>
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

        /// <summary>
        /// Display of the GSM.
        /// </summary>
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

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
            private set
            {
                this.callHistory = value;
            }
        }

        public static GSM IPhone
        {
            get
            {
                return iPhone;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new GSM. Model and manifacturer are mandatory.
        /// </summary>
        /// <param name="inputModel">Model of the GSM.</param>
        /// <param name="inputManifacturer">Manifacturer of the GSM</param>
        public GSM(string inputModel, string inputManifacturer)
            : this(inputModel, inputManifacturer, null)
        {
        }

        /// <summary>
        /// Creates a new GSM. Model and manifacturer are mandatory.
        /// </summary>
        /// <param name="inputModel">Model of the GSM.</param>
        /// <param name="inputManifacturer">Manifacturer of the GSM.</param>
        /// <param name="inputPrice">Price of the GSM.</param>
        public GSM(string inputModel, string inputManifacturer, decimal? inputPrice)
            : this(inputModel, inputManifacturer, inputPrice, null)
        {
        }

        /// <summary>
        /// Creates a new GSM. Model and manifacturer are mandatory.
        /// </summary>
        /// <param name="inputModel">Model of the GSM.</param>
        /// <param name="inputManifacturer">Manifacturer of the GSM.</param>
        /// <param name="inputPrice">Price of the GSM.</param>
        /// <param name="inputOwner">Owner of the GSM.</param>
        public GSM(string inputModel, string inputManifacturer, decimal? inputPrice, string inputOwner)
            : this(inputModel, inputManifacturer, inputPrice, inputOwner, null)
        {
        }

        /// <summary>
        /// Creates a new GSM. Model and manifacturer are mandatory.
        /// </summary>
        /// <param name="inputModel">Model of the GSM.</param>
        /// <param name="inputManifacturer">Manifacturer of the GSM.</param>
        /// <param name="inputPrice">Price of the GSM.</param>
        /// <param name="inputOwner">Owner of the GSM.</param>
        /// <param name="inputBattery">Battery of the GSM.</param>
        public GSM(string inputModel, string inputManifacturer, decimal? inputPrice, string inputOwner, Battery inputBattery)
            : this(inputModel, inputManifacturer, inputPrice, inputOwner, inputBattery, null)
        {
        }

        /// <summary>
        /// Creates a new GSM. Model and manifacturer are mandatory.
        /// </summary>
        /// <param name="inputModel">Model of the GSM.</param>
        /// <param name="inputManifacturer">Manifacturer of the GSM.</param>
        /// <param name="inputPrice">Price of the GSM.</param>
        /// <param name="inputOwner">Owner of the GSM.</param>
        /// <param name="inputBattery">Battery of the GSM.</param>
        /// <param name="inputDisplay">Display of the GSM.</param>
        public GSM(string inputModel, string inputManifacturer, decimal? inputPrice, string inputOwner, Battery inputBattery, Display inputDisplay)
        {
            this.Model = inputModel;
            this.Manifacturer = inputManifacturer;
            this.Price = inputPrice;
            this.Owner = inputOwner;
            this.Battery = inputBattery;
            this.Display = inputDisplay;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a call to the call history.
        /// </summary>
        /// <param name="inputDialedPhone">Dialed phone number. Can be in any given format.</param>
        /// <param name="inputDuration">Duration of the phone call in seconds.</param>
        public void AddCall(string inputDialedPhone, uint inputDuration)
        {
            this.CallHistory.Add(new Call(inputDialedPhone, inputDuration));
        }

        /// <summary>
        /// Deletes a call at a given index from the call history.
        /// </summary>
        /// <param name="index">Index of the call to be deleted.</param>
        public void DeleteCall(int index)
        {
            if (index >= 0 && index < callHistory.Count)
            {
                this.CallHistory.RemoveAt(index);
            }
            else
            {
                throw new ArgumentOutOfRangeException("There is no call at the required place!");
            }
        }

        /// <summary>
        /// Clears the call history.
        /// </summary>
        public void ClearHistory()
        {
            this.CallHistory.Clear();
        }

        /// <summary>
        /// Calculates the total price of all calls in the call history of the GSM.
        /// </summary>
        /// <param name="pricePerMinute">Price per minute.</param>
        /// <returns>The total price of all calls.</returns>
        public decimal TotalCallPrice(decimal pricePerMinute)
        {
            uint minutes = 0;
            uint remainder = 0;

            for (int i = 0; i < CallHistory.Count; i++) // Not sure if I should use the property or the field.
            {
                minutes += CallHistory[i].Duration / 60;
                remainder += CallHistory[i].Duration % 60;

                if (remainder != 0)
                {
                    minutes++;
                }
            }

            return pricePerMinute * minutes;
        }

        /// <summary>
        /// Deletes the longes call in the call history.
        /// </summary>
        public void DeleteLongestCall()
        {
            int longestCallIndex = 0;
            uint duration = 0;
            for (int i = 0; i < CallHistory.Count; i++)
            {
                if (CallHistory[i].Duration > duration)
                {
                    duration = CallHistory[i].Duration;
                    longestCallIndex = i;
                }
            }

            CallHistory.RemoveAt(longestCallIndex);
        }

        /// <summary>
        /// Displays the information about the phone.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Phone model: {0}\nPhone manifacturer: {1}\nPhone price: {2}\nPhone owner: {3}\n\nPhone battery data:\n{4}\n\nPhone display data:\n{5}", this.Model, this.Manifacturer, this.Price, this.Owner, this.Battery, this.Display);
        }
        #endregion
    }
}

