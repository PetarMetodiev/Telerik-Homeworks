namespace StudetsAndWorkers
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string inputFirstName, string inputLastName, decimal inputWeekSalary, int inputWorkHoursPerDay)
            : base(inputFirstName, inputLastName)
        {
            this.WeekSalary = inputWeekSalary;
            this.WorkHoursPerDay = inputWorkHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Invalid Week Salary!");
                }
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            private set
            {
                if (value < 2 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("Invalid work hours!");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            int workdays = 5;
            decimal moneyPerDay = this.WeekSalary / (decimal)workdays;
            decimal moneyPerHour = moneyPerDay / (decimal)this.WorkHoursPerDay;
            return moneyPerHour;
        }

        public override string ToString()
        {
            StringBuilder workerInfo = new StringBuilder();
            workerInfo.Append("Name: " + this.FirstName + " " + this.LastName);
            workerInfo.AppendLine();
            workerInfo.Append(string.Format("Money per hour: {0:F2}", this.MoneyPerHour()));
            workerInfo.AppendLine();
            return workerInfo.ToString();
        }
    }
}
