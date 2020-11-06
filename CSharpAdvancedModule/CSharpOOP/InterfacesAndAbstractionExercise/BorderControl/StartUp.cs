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
            List<ICheck> checkList = new List<ICheck>();
            List<IBirthday> birthdayList = new List<IBirthday>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = inputData[1];
                string id = string.Empty;
                string birthday = string.Empty;

                if (inputData[0] == "Robot")
                {
                    id = inputData[2];
                    
                    Robot robot = new Robot(name, id);
                    checkList.Add(robot);
                }
                else if(inputData[0] == "Citizen")
                {
                    int age = int.Parse(inputData[2]);
                    id = inputData[3];
                    birthday = inputData[4];
                    
                    Citizen citizen = new Citizen(name, age, id, birthday);
                    birthdayList.Add(citizen);
                }
                else if (inputData[0] == "Pet")
                {
                    birthday = inputData[2];
                    Pet pet = new Pet(name, birthday);
                    birthdayList.Add(pet);
                }
            }
            string yearOfBirth = Console.ReadLine();


            foreach (var item in birthdayList)
            {
                if (item.Birthday.EndsWith(yearOfBirth))
                {
                    Console.WriteLine(item.Birthday);
                }
            }

        }
    }
 }

