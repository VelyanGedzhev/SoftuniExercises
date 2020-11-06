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
            string input = string.Empty;
            List<IAddable> checkList = new List<IAddable>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputData.Length == 2)
                {
                    string modelName = inputData[0];
                    string id = inputData[1];
                    Robot robot = new Robot(modelName, id);
                    checkList.Add(robot);
                }
                else
                {
                    string name = inputData[0];
                    int age = int.Parse(inputData[1]);
                    string id = inputData[2];
                    Citizen citizen = new Citizen(name, age, id);
                    checkList.Add(citizen);
                }
            }
            string fakeId = Console.ReadLine();


            foreach (var item in checkList)
            {
                if (item.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(item.Id);
                }
            }

        }
    }
}
