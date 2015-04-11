namespace RangeExceptions
{
    using System;

    class Start
    {
        static void Main()
        {
            int startNumber = 1;
            int endNumber = 100;
            int testNumber = 123;

            DateTime startDate = new DateTime(1980, 1, 1);
            DateTime endDate = new DateTime(2013, 12, 31);
            DateTime testDate = DateTime.Today;

            //if (testNumber < startNumber || testNumber > endNumber)
            //{
            //    throw new InvalidRangeException<int>("Invalid number", startNumber, endNumber);
            //}

            //if (testDate<startDate || testDate > endDate)
            //{
            //    throw new InvalidRangeException<DateTime>("Invalid date!", startDate, endDate);
            //}
        }
    }
}
