using System;

namespace _3._LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            FindPointClosestToCenter(
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine())
                );
        }
        static void FindPointClosestToCenter(double x1, double y1, double x2, double y2,
            double x3, double y3, double x4, double y4)
        {
            double firstPoint = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            double secondPoint = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));
            double thirdPoint = Math.Sqrt(Math.Pow(x3, 2) + Math.Pow(y3, 2));
            double fourthPoint = Math.Sqrt(Math.Pow(x4, 2) + Math.Pow(y4, 2));

            if (FindLongestLine(x1, y1, x2, y2, x3, y3, x4, y2))
            {
                if(firstPoint < secondPoint)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else if(firstPoint > secondPoint)
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
            else
            {
                if (thirdPoint < fourthPoint)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else if (thirdPoint > fourthPoint)
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }
            
            
        }
        static bool FindLongestLine(double x1, double y1, double x2, double y2,
            double x3, double y3, double x4, double y4)
        {
            double firstDistance = Math.Sqrt(Math.Pow(Math.Pow(x1 + y1, 2) + Math.Pow(x2 + y2, 2), 2));
            double secondDistance = Math.Sqrt(Math.Pow(Math.Pow(x3 + y3, 2) + Math.Pow(x4 + y4, 2), 2));

            bool longestLine = false;

            if (firstDistance > secondDistance)
            {
                longestLine = true;
            }
            else if(firstDistance < secondDistance)
            {
                longestLine = false;
            }
            else
            {
                longestLine = true;
            }

            return longestLine;
        }
    }
}
//using System;
//using System.Collections.Generic;
 
//class LongerLine
//{
//    static void Main()
//    {
//        double x1 = double.Parse(Console.ReadLine());
//        double y1 = double.Parse(Console.ReadLine());

//        double x2 = double.Parse(Console.ReadLine());
//        double y2 = double.Parse(Console.ReadLine());

//        double x3 = double.Parse(Console.ReadLine());
//        double y3 = double.Parse(Console.ReadLine());

//        double x4 = double.Parse(Console.ReadLine());
//        double y4 = double.Parse(Console.ReadLine());

//        double lineA = CalculateLineLength(x1, y1, x2, y2);
//        double lineB = CalculateLineLength(x3, y3, x4, y4);


//        if (lineA >= lineB && CheckCloserPoint(x1, y1, x2, y2))
//        {
//            Console.Write($"({x1}, {y1}) ({x2}, {y2})");
//        }
//        else if (lineA >= lineB && CheckCloserPoint(x1, y1, x2, y2) == false)
//        {
//            Console.Write($"({x2}, {y2}) ({x1}, {y1})");
//        }
//        else if (lineA < lineB && CheckCloserPoint(x3, y3, x4, y4))
//        {
//            Console.Write($"({x3}, {y3}) ({x4}, {y4})");
//        }
//        else if (lineA < lineB && CheckCloserPoint(x3, y3, x4, y4) == false)
//        {
//            Console.Write($"({x4}, {y4})({x3}, {y3})");
//        }

//    }

//    private static bool CheckCloserPoint(double x1, double y1, double x2, double y2)
//    {
//        bool isCloserToZero = false;
//        double dist1 = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
//        double dist2 = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));

//        if (dist1 <= dist2)
//        {
//            isCloserToZero = true;
//        }
//        return isCloserToZero;
//    }

//    private static double CalculateLineLength(double x1, double y1, double x2, double y2)
//    {
//        double lineLength = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
//        return lineLength;
//    }
//}