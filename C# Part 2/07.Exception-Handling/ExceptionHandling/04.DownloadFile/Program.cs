﻿
// Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
// and stores it the current directory. Find in Google how to download files in C#. 
// Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.Net;

class DownloadFile
{
    static void Main()
    {
        using (WebClient webClient = new WebClient())
        {
            string addres = @"http://www.devbg.org/img/Logo-BASD.jpg";
            string filePath = @"..\..\downloads\logo.jpg";
            try
            {
                webClient.DownloadFile(addres, filePath);
                Console.WriteLine("Download complete!");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The address parameter is null");
            }
            catch (WebException)
            {
                Console.WriteLine("The address is invalid.");
            }

            catch (NotSupportedException)
            {
                Console.WriteLine("The method has been called simultaneously on multiple threads.");
            }
        }
    }
}