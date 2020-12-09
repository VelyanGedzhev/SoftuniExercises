using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly IList<IComputer> computers;
        private readonly IList<IComponent> components;
        private readonly IList<IPeripheral> peripherals;
        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            DoesComputerExist(computerId);

            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = CreateComponent(id, componentType, manufacturer, model, price, overallPerformance, generation);

            components.Add(component);

            computers.FirstOrDefault(x => x.Id == computerId).AddComponent(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer;

            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            computer = CreatComputer(computerType, id, manufacturer, model, price);

            computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            DoesComputerExist(computerId);

            if (peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = CreatePeripheral(id, peripheralType, manufacturer, model, price, overallPerformance, connectionType);


            peripherals.Add(peripheral);
            computers.FirstOrDefault(x => x.Id == computerId).AddPeripheral(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            var topComputer = computers.OrderByDescending(c => c.OverallPerformance).ThenByDescending(c => c.Price).FirstOrDefault(c => c.Price <= budget);

            if (topComputer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(topComputer);

            return topComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            DoesComputerExist(id);

            var computer = computers.FirstOrDefault(x => x.Id == id);

            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            DoesComputerExist(id);

            var computer = computers.FirstOrDefault(x => x.Id == id);
            

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            DoesComputerExist(computerId);

            
            IComputer computer =  computers.FirstOrDefault(x => x.Id == computerId);
            IComponent componentToRemove = computer.Components.FirstOrDefault(x => x.GetType().Name == componentType);

            computer.RemoveComponent(componentType);

            return string.Format(SuccessMessages.RemovedComponent, componentType, componentToRemove.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            DoesComputerExist(computerId);

            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            IPeripheral peripheralToRemove = computer.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            computer.RemovePeripheral(peripheralType);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheralToRemove.Id);
        }

        private static IComputer CreatComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer;
            if (computerType == ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == ComputerType.DesktopComputer.ToString())
            {

                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            return computer;
        }

        private static IComponent CreateComponent(int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            Enum.TryParse(componentType, out ComponentType typeOfComponent);
            IComponent component = typeOfComponent switch
            {
                ComponentType.CentralProcessingUnit => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.Motherboard => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };

            return component;
        }

        private static IPeripheral CreatePeripheral(int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            Enum.TryParse(peripheralType, out PeripheralType typeOfPeripheral);
            IPeripheral peripheral = typeOfPeripheral switch
            {
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };

            return peripheral;
        }

        private void DoesComputerExist(int id)
        {
            if (!computers.Any( x=> x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
