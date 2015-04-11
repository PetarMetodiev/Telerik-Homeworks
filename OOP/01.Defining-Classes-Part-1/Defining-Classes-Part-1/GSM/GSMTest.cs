namespace GSM
{
    using System;

    public class GSMTest
    {
        public static void Main()
        {
            #region Problem 7
            Console.WriteLine("PROBLEM 7");
            Console.WriteLine();
            Console.WriteLine();

            GSM[] phones = new GSM[3];

            phones[0] = new GSM("One M9", "HTC", 555, "Gosho", new Battery("Aziatska", 50, 20, BatteryType.LiIon), new Display(5.0, 16000000));
            phones[1] = new GSM("Galaxy S6", "Samsung", 777, "Peio", new Battery("Albanska", 40, 15, BatteryType.LiIon), new Display(5.1, 16000000));
            phones[2] = new GSM("G3", "LG", 444, "Stamat", new Battery("Evropeiska", 60, 25, BatteryType.LiIon), new Display(5.5, 16000000));

            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine(GSM.IPhone);

            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region Problem 12
            Console.WriteLine("PROBLEM 12");
            Console.WriteLine();
            Console.WriteLine();

            GSM myGSM = new GSM("Gazarski", "Krusha", 1234M, "Misho Shamara", new Battery("Moderna", 600, 200, BatteryType.LiIon), new Display(6, 16000000));

            //int sleep = 1000;

            myGSM.AddCall("+35988775566", 366);
            // Thread.Sleep(sleep); // Just to add some time between the calls.
            myGSM.AddCall("0883666999", 5586);
            // Thread.Sleep(sleep);
            myGSM.AddCall("02 992 3323", 12);
            // Thread.Sleep(sleep);

            foreach (var call in myGSM.CallHistory)
            {
                Console.WriteLine(call);
                Console.WriteLine();
            }

            decimal pricePerMinute = 0.37M;

            Console.WriteLine("Total price of calls: " + myGSM.TotalCallPrice(pricePerMinute));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Deleting longest call...");
            Console.WriteLine();

            myGSM.DeleteLongestCall();

            foreach (var call in myGSM.CallHistory)
            {
                Console.WriteLine(call);
                Console.WriteLine();
            }

            Console.WriteLine("Total price of calls: " + myGSM.TotalCallPrice(0.37M));
            Console.WriteLine();

            myGSM.ClearHistory();
            Console.WriteLine("Call list after clean-up:");
            Console.WriteLine();

            foreach (var call in myGSM.CallHistory)
            {
                Console.WriteLine(call);
                Console.WriteLine();
            }
            #endregion
        }
    }
}
