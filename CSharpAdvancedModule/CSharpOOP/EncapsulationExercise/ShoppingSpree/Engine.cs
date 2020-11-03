

using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Engine
    {
        private readonly ICollection<Person> people;
        private readonly ICollection<Product> products;
        public Engine()
        {
            people = new List<Person>();
            products = new List<Product>();

        }
        public void Run()
        {
            
            try
            {
                ReadPeopleInput();
                ReadProductsInput();
                string command = string.Empty;

                while ((command = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string personName = cmdArgs[0];
                    string productName = cmdArgs[1];

                    Person person = people.FirstOrDefault(n => n.Name == personName);
                    Product product = products.FirstOrDefault(n => n.Name == productName);

                    if (person != null || product != null)
                    {
                        string result = person.BuyProducts(product);

                        Console.WriteLine(result);
                    }
                }

                foreach (Person person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void ReadPeopleInput()
        {
            string[] peopleArgs = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (string personString in peopleArgs)
            {
                string[] personArgs = personString.Split("=");

                string personName = personArgs[0];
                decimal personMoney = decimal.Parse(personArgs[1]);

                Person person = new Person(personName, personMoney);
                people.Add(person);
            }
        }
        private void ReadProductsInput()
        {
            string[] productsArgs = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (string productString in productsArgs)
            {
                string[] personArgs = productString.Split("=");

                string productName = personArgs[0];
                decimal productCost = decimal.Parse(personArgs[1]);

                Product product = new Product(productName, productCost);
                products.Add(product);
                
            }
        }
    }
}
