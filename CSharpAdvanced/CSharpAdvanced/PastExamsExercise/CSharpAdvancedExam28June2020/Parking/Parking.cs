using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        
        public Parking(string type, int capacity)
        {
            ParkingData = new List<Car>();
            Type = type;
            Capacity = capacity;
        }
        public int Count => ParkingData.Count;
        public List<Car> ParkingData { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public void Add(Car car)
        {
            if (Capacity > Count)
            {
                ParkingData.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = ParkingData.Where(x => x.Manufacturer == manufacturer).FirstOrDefault(y => y.Model == model);
            return ParkingData.Remove(carToRemove);
        }
        public Car GetLatestCar()
        {
            if (Count == 0)
            {
                return null;
            }
            else
            {
                return ParkingData.OrderByDescending(x => x.Year).FirstOrDefault();
            }
        }
        public Car GetCar(string manufacturer, string model)
        {
            return ParkingData.Where(x => x.Manufacturer == manufacturer).FirstOrDefault(y => y.Model == model);
                
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (Car car in ParkingData)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
