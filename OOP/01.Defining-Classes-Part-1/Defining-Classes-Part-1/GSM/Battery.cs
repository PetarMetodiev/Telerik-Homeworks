namespace GSM
{
    using System;

    public class Battery
    {
        #region Fields
        private string model;       // Mandatory
        private double? hoursIdle;
        private double? hoursTalk;
        private BatteryType batteryType;
        #endregion

        #region Properties
        /// <summary>
        /// Model of the battery. If invalid data is entered an exception is thrown.
        /// </summary>
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The batery model has to be entered!");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        /// <summary>
        /// Idle time capacity of the battery in hours. If invalid data is entered an exception is thrown.
        /// </summary>
        public double? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The hours idle have to be positive!");
                }
                else
                {
                    this.hoursIdle = value;
                }
            }
        }

        /// <summary>
        /// Talk time capacity of the battery in hours. If invalid data is entered an exception is thrown.
        /// </summary>
        public double? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The hours talk have to be positive!");
                }
                else
                {
                    this.hoursTalk = value;
                }
            }
        }

        /// <summary>
        /// Battery type.
        /// </summary>
        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                this.batteryType = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new battery. The model is mandatory.
        /// </summary>
        /// <param name="inputModel">Model of the battery.</param>
        public Battery(string inputModel)
            : this(inputModel, null)
        {
        }

        /// <summary>
        /// Creates a new battery. The model is mandatory.
        /// </summary>
        /// <param name="inputModel">Model of the battery.</param>
        /// <param name="inputHoursIdle">Idle time capacity of the battery in hours.</param>
        public Battery(string inputModel, double? inputHoursIdle)
            : this(inputModel, inputHoursIdle, null)
        {
        }

        /// <summary>
        /// Creates a new battery. The model is mandatory.
        /// </summary>
        /// <param name="inputModel">Model of the battery.</param>
        /// <param name="inputHoursIdle">Idle time capacity of the battery in hours.</param>
        /// <param name="inputHoursTalk">Talk time capacity of the battery in hours.</param>
        public Battery(string inputModel, double? inputHoursIdle, double? inputHoursTalk)
            : this(inputModel, inputHoursIdle, inputHoursTalk, BatteryType.Unknown)
        {
        }

        /// <summary>
        /// Creates a new battery. The model is mandatory.
        /// </summary>
        /// <param name="inputModel">Model of the battery.</param>
        /// <param name="inputHoursIdle">Idle time capacity of the battery in hours.</param>
        /// <param name="inputHoursTalk">Talk time capacity of the battery in hours.</param>
        /// <param name="inputBatteryType">Type of the battery.</param>
        public Battery(string inputModel, double? inputHoursIdle, double? inputHoursTalk, BatteryType inputBatteryType)
        {
            this.Model = inputModel;
            this.HoursIdle = inputHoursIdle;
            this.HoursTalk = inputHoursTalk;
            this.BatteryType = inputBatteryType;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Displays information about the batery.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Battery model: {0}\nHours Idle: {1}\nHours Talk: {2}\nBattery type: {3}", this.Model, this.HoursIdle, this.HoursTalk, this.BatteryType);
        }
        #endregion
    }
}
