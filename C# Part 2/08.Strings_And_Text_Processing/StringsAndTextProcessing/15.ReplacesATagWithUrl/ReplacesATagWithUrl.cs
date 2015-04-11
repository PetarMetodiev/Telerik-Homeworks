﻿using System;
using System.Text.RegularExpressions;

class ReplacesATagWithUrl
{
    //Write a program that replaces in a HTML document given as string all 
    //the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. 
    //Sample HTML fragment:
    //<p>Please visit <a href="http://academy.telerik. com">our site</a> 
    //to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
    //Result: 
    //<p>Please visit [URL=http://academy.telerik. com]our site[/URL] 
    //to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>



    static void Main()
    {
        string text = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a>" +
        "to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        string resultText = Regex.Replace(text, "<a href=\"(.*?)\">(.*?)</a>", "[URL=$1]$2[/URL]");
        Console.WriteLine(resultText);
    }
}
