using System;

namespace _3._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string weekDay = Console.ReadLine();
            double totalPrice = 0;

            switch (groupType)
            {
                case "Students":
                    if(groupCount >= 30)
                    {
                        switch (weekDay)
                        {
                            case "Friday":
                                totalPrice = groupCount * 8.45;
                                break;
                            case "Saturday":
                                totalPrice = groupCount * 9.8;
                                break;
                            case "Sunday":
                                totalPrice = groupCount * 10.46;
                                break; 
                        }
                        totalPrice = totalPrice * 0.85;
                    }
                    else
                    {
                        switch (weekDay)
                        {
                            case "Friday":
                                totalPrice = groupCount * 8.45;
                                break;
                            case "Saturday":
                                totalPrice = groupCount * 9.8;
                                break;
                            case "Sunday":
                                totalPrice = groupCount * 10.46;
                                break;
                        }
                    }
                    break;
                case "Business":
                    if(groupCount >= 100)
                    {
                        double discount = 0;
                        switch (weekDay)
                        {
                            case "Friday":
                                totalPrice = groupCount * 10.9;
                                discount = 10 * 10.9;
                                break;
                            case "Saturday":
                                totalPrice = groupCount * 15.6;
                                discount = 10 * 15.6;
                                break;
                            case "Sunday":
                                totalPrice = groupCount * 16.0;
                                discount = 10 * 16.0;
                                break;
                        } 
                        totalPrice -= discount;
                    }
                    else
                    {
                        switch (weekDay)
                        {
                            case "Friday":
                                totalPrice = groupCount * 10.9;
                                break;
                            case "Saturday":
                                totalPrice = groupCount * 15.6;
                                break;
                            case "Sunday":
                                totalPrice = groupCount * 16.0;
                                break;
                        }
                    }
                    break;
                case "Regular":
                    if(groupCount >= 10 && groupCount <= 20)
                    {
                        switch (weekDay)
                        {
                            case "Friday":
                                totalPrice = groupCount * 15.0;
                                break;
                            case "Saturday":
                                totalPrice = groupCount * 20.0;
                                break;
                            case "Sunday":
                                totalPrice = groupCount * 22.50;
                                break;
                        }
                        totalPrice = totalPrice * 0.95;
                    }
                    else
                    {
                        switch (weekDay)
                        {
                            case "Friday":
                                totalPrice = groupCount * 15.0;
                                break;
                            case "Saturday":
                                totalPrice = groupCount * 20.0;
                                break;
                            case "Sunday":
                                totalPrice = groupCount * 22.50;
                                break;
                        }
                    }
                    break;
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
