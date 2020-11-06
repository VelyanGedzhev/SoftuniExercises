using BorderControl.Interfaces;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           
            List<IBuyer> buyers = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = inputData[0];
                int age = int.Parse(inputData[1]);

                if (inputData.Length == 4)
                {
                    string id = inputData[2];
                    string birthday = inputData[3];
                    Citizen citizen = new Citizen(name, age, id, birthday);
                    buyers.Add(citizen);
                }
                else
                {
                    string group = inputData[2];
                    Rebel rebel = new Rebel(name, group);
                    buyers.Add(rebel);
                }
            }
            string buyer = string.Empty;
            int foodSum = 0;

            while ((buyer = Console.ReadLine())!="End")
            {
                foreach (var item in buyers)
                {
                    if (item.Name == buyer)
                    {
                        foodSum += item.BuyFood();
                        
                    }
                    
                }
            }
            Console.WriteLine(foodSum);
            
        }
    }
 }

