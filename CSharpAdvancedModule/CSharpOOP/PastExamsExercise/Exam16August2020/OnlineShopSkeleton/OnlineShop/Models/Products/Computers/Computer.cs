using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.ToList().AsReadOnly();

        public override decimal Price => Peripherals.Sum(x => x.Price) + Components.Sum(x => x.Price);

        public override double OverallPerformance => CalculateOverallPerformance();

        public void AddComponent(IComponent component)
        {
            if (components.Any(t => t.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, GetType().Name, Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(t => t.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, GetType().Name, Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count == 0 || !components.Any(t => t.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, GetType().Name, Id));
            }

            IComponent componentToRemove = components.FirstOrDefault(t => t.GetType().Name == componentType);

            components.Remove(componentToRemove);

            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count == 0 || !peripherals.Any(t => t.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, GetType().Name, Id));
            }

            IPeripheral peripheralToRemove = peripherals.FirstOrDefault(t => t.GetType().Name == peripheralType);

            peripherals.Remove(peripheralToRemove);

            return peripheralToRemove;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine(string.Format(SuccessMessages.ComputerComponentsToString, Components.Count));

            foreach (var component in Components)
            {
                sb.AppendLine(component.ToString());
            }

            sb.AppendLine(string.Format(SuccessMessages.ComputerPeripheralsToString,  Peripherals.Count, 
              Peripherals.Average(p => p.OverallPerformance)));

            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine(peripheral.ToString());
            }

            return base.ToString() + Environment.NewLine + sb.ToString().TrimEnd();
        }

        private double CalculateOverallPerformance()
        {
            if (Components.Count == 0)
            {
                return base.OverallPerformance;
            }
            else
            {
                return base.OverallPerformance + Components.Average(c => c.OverallPerformance);
            }
        }
    }
}
