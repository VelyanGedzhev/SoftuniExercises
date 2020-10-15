using System;

namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();
            var result =  dateModifier.GetDays(startDate, endDate);
            Console.WriteLine(Math.Abs(result));
        }
    }
}
