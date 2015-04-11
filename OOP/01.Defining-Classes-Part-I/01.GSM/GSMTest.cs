using System;
using System.Collections.Generic;

class GSMTest
{
    static void Main()
    {
        Console.WriteLine(GSM.IPhone);

        GSM[] mobilePhones = new GSM[3];
        mobilePhones[0] = new GSM("Galaxy S4", "Samsung", 1000, "John", new Battery("Samsung", 350, 17, BatteryType.LiIon), new Display(5.0, "16M"));
        mobilePhones[1] = new GSM("Galaxy S3", "Samsung", 800, "Peter", new Battery("Samsung", 590, 12, BatteryType.LiIon), new Display(4.7, "16M"));
        mobilePhones[2] = new GSM("Galaxy S2", "Samsung", 600, "Simon", new Battery("Samsung", 710, 9, BatteryType.LiIon), new Display(4.3, "16M"));

        for (int i = 0; i < mobilePhones.Length; i++)
        {
            Console.WriteLine();
            Console.WriteLine(mobilePhones[i]);
        }

        Console.WriteLine();
        Console.WriteLine();

        GSM myGSM = new GSM("3310", "Nokia");

        decimal pricePerMinute = 0.12M;

        myGSM.AddCall("+359123456789", 12);
        for (uint i = 1; i < 20; i++)
        {
            myGSM.AddCall("+359123456788", i);
        }


        List<Call> callHistory = myGSM.CallLog;

        for (int i = 0; i < callHistory.Count; i++)
        {
            Console.WriteLine(callHistory[i]);
        }

        Console.WriteLine("Total price for the calls: {0}", myGSM.CallPrice(pricePerMinute));

        // Remove longest call.
        int max = 0;
        uint duration = 0;
        for (int i = 0; i < callHistory.Count; i++)
        {
            if (callHistory[i].Duration > duration)
            {
                duration = callHistory[i].Duration;
                max = i;
            }
        }

        myGSM.DeleteCall(max);

        Console.WriteLine("Total price for the calls: {0}", myGSM.CallPrice(pricePerMinute));

        myGSM.ClearCallHistory();

        // Just to show that the call history is empty.
        for (int i = 0; i < callHistory.Count; i++)
        {
            Console.WriteLine(callHistory[i]);
        }
    }
}
