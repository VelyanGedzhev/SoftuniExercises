using System;
using System.Collections.Generic;

namespace _6.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> parking = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(", ");
                string car = command[1];

                if (command[0] == "IN")
                {
                    parking.Add(car);
                }
                else
                {
                    parking.Remove(car);
                }
            }
            if (parking.Count > 0)
            {
                foreach (var item in parking)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
