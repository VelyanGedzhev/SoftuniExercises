using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> clinicData;
        public Clinic(int capacity)
        {
            Capacity = capacity;
            clinicData = new List<Pet>();
        }

        public int Capacity { get; set; }
        
        public int Count
        {
            get
            {
                return clinicData.Count;
            }
        }

        public void Add(Pet pet)
        {
            if (Capacity > Count)
            {
                clinicData.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            //Pet petToRemove = clinicData.FirstOrDefault(x => x.Name == name);
            //return clinicData.Remove(petToRemove);
            bool isRemovedByName = false;
            for (int i = 0; i < clinicData.Count; i++)
            {
                var currPetName = clinicData[i].Name;
                if (currPetName == name)
                {
                    clinicData.RemoveAt(i);
                    isRemovedByName = true;
                }
            }

            return isRemovedByName;
        }
        public Pet GetPet(string name, string owner)
        {
            //Pet petToReturn = clinicData.Where(n => n.Name == name).FirstOrDefault(o => o.Owner == owner);
            //return petToReturn;
            for (int i = 0; i < clinicData.Count; i++)
            {
                var currPetName = clinicData[i].Name;
                var currOwner = clinicData[i].Owner;
                if (currPetName == name && currOwner == owner)
                    return clinicData[i];

            }
            return null;
        }
        public Pet GetOldestPet()
        {
            return clinicData.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients: ");

            foreach (Pet pet in clinicData)
            {
                sb.AppendLine($"Pet {pet.Name} with onwer {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
