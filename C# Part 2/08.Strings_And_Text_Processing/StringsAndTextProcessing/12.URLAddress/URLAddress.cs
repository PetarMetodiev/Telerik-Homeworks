using System;
using System.Text;
using System.Text.RegularExpressions;

class URLAddress
{
    //Write a program that parses an URL address given in the format:
    //[protocol]://[server]/[resource]
    //and extracts from it the [protocol], [server] and [resource] elements. 
    //For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
    //[protocol] = "http"
    //[server] = "www.devbg.org"
    //[resource] = "/forum/index.php"



    static void Main()
    {
        Console.Write("URL: ");
        string urlAddress = Console.ReadLine(); //"http://www.devbg.org/forum/index.php";
        string protocolPattern = "[^:]*";
        string serverPattern = @"/([^/][\w\.]*)";
        string resourcePattern = @"\b/[^/][\w.]*.+";

        Match matchProtocol = Regex.Match(urlAddress, protocolPattern);
        Match matchServer = Regex.Match(urlAddress, serverPattern);
        Match matchResource = Regex.Match(urlAddress, resourcePattern);

        Console.WriteLine("[protocol] = \"{0}\"", matchProtocol);
        Console.WriteLine("[server] = \"{0}\"", matchServer.Groups[1]);
        Console.WriteLine("[resource] = \"{0}\"", matchResource);

        Console.WriteLine(new string('-', 40));

        //When can't find the right expression pattern
        string[] urlArr = urlAddress.Split(':');
        string protocol = urlArr[0];
        string[] addressArr = urlArr[1].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
        string server = addressArr[0];
        StringBuilder resource = new StringBuilder();
        for (int i = 1; i < addressArr.Length; i++)
        {
            resource.Append("/");
            resource.Append(addressArr[i]);
        }
        Console.WriteLine("[protocol] = \"{0}\"", protocol);
        Console.WriteLine("[server] = \"{0}\"", server);
        Console.WriteLine("[resource] = \"{0}\"", resource);

    }
}
