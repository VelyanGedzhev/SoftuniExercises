using System;
using _1.Car;


namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            

            Engine engine = new Engine(650, 1000);
            Tires[] tires = new Tires[]
            {
                new Tires(2008, 1200),
                new Tires(2008, 1200),
                new Tires(2008, 1200),
                new Tires(2008, 1200)
            };
            var car = new Car("Lambo", "Urus", 2010, 250, 9, engine, tires);
            
            Console.WriteLine(car.WhoAmI());
        }
    }
}
