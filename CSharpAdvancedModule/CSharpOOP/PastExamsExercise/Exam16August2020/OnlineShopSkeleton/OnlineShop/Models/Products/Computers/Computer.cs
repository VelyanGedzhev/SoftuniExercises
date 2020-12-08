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
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.ToList().AsReadOnly();

        public override decimal Price
        {
            get => GetComponenetsSum() + GetPeripheralsSum();
        }

        public override double OverallPerformance
        {
            get
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

        public void AddComponent(IComponent component)
        {
            if (components.Any(t => t.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {GetType().Name} with Id {Id}.");
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(t => t.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripeheral {peripheral.GetType().Name} already exists in {GetType().Name} with Id {Id}.");
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count == 0 || !components.Any(t => t.GetType().Name == componentType))
            {
                throw new ArgumentException($"Component {componentType} does not exist in {GetType().Name} with Id {Id}.");
            }

            IComponent componentToRemove = components.FirstOrDefault(t => t.GetType().Name == componentType);

            components.Remove(componentToRemove);

            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count == 0 || !peripherals.Any(t => t.GetType().Name == peripheralType))
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {GetType().Name} with Id {Id}.");
            }

            IPeripheral peripheralToRemove = peripherals.FirstOrDefault(t => t.GetType().Name == peripheralType);

            peripherals.Remove(peripheralToRemove);

            return peripheralToRemove;
        }

        private decimal GetComponenetsSum()
        {
            decimal sum = 0;

            foreach (var component in components)
            {
                sum += component.Price;
            }
            return sum;
        }

        private decimal GetPeripheralsSum()
        {
            decimal sum = 0;

            foreach (var peripheral in peripherals)
            {
                sum += peripheral.Price;
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($" Components ({Components.Count}):");

            foreach (var component in Components)
            {
                sb.AppendLine(component.ToString());
            }

            sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({Peripherals.Average(p => p.OverallPerformance)}):");

            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine(peripheral.ToString());
            }

            return base.ToString() + Environment.NewLine + sb.ToString().TrimEnd();
        }
    }
}
