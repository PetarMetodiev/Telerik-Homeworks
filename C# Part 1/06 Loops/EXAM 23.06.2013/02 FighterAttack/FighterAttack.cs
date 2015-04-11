using System;

class FighterAttack
{
    static void Main()
    {
        int px1 = int.Parse(Console.ReadLine());
        int py1 = int.Parse(Console.ReadLine());
        int px2 = int.Parse(Console.ReadLine());
        int py2 = int.Parse(Console.ReadLine());
        int fx = int.Parse(Console.ReadLine());
        int fy = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());

        int temp;

        if (px1 > px2)
	    {
		    temp = px1;
            px1 = px2;
            px2 = temp;
	    }

        if (py1 > py2)
	    {
		    temp = py1;
            py1 = py2;
            py2 = temp;
	    }

        int fiftyPercent = 50;
        int seventyFivePercent = 75;
        int hundredPercent = 100;
        int score = 0;

        int hitX = fx + d;
        int hitY = fy;

        // bool leftCorners = (hitX == px1 && hitY == py1) || (hitX == px1 && hitY == py2);
        bool rightCorners = (hitX == px2 && hitY == py1) || (hitX == px2 && hitY == py2);
        bool inside = hitX < px2 && hitX >= px1 && hitY > py1 && hitY < py2;
        bool rightEdge = hitX == px2 && (hitY < py2 && hitY > py1);
        bool horizontalEdge = (hitX >= px1 && hitX < px2) && (hitY == py1 || hitY == py2);
        bool leftOut = hitX < px1 && (hitY <= py2 && hitY >= py1);
        bool topBottomOut = (hitX >= px1 && hitX <= px2) && (hitY > py2 || hitY < py1);

        if (inside)
        {
            score = 2 * fiftyPercent + seventyFivePercent + hundredPercent;
        }
        else if (horizontalEdge)
        {
            score = hundredPercent + seventyFivePercent + fiftyPercent;
        }
        else if (rightCorners)
        {
            score = hundredPercent + fiftyPercent;
        }
        else if (rightEdge)
        {
            score = 2 * fiftyPercent + hundredPercent;
        }
        else if (leftOut)
        {
            score = seventyFivePercent;
        }
        else if (topBottomOut)
        {
            score = fiftyPercent;
        }
        else
        {
            score = 0;
        }

        Console.WriteLine("{0}%", score);
    }
}
