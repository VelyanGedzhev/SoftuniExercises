using System;

namespace Prototype
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Drink drink = new Drink("Coke");

            Sandwich originalSandwich = new Sandwich("white", "emmental", "tomatoes", "chorizo", drink);

            Sandwich shallowCopySandwich = originalSandwich.ShallowClone();
            Sandwich deepCopySandwich = originalSandwich.DeepClone();

            Console.WriteLine($"Original {originalSandwich}");
            Console.WriteLine($"ShallowCopy {shallowCopySandwich}");
            Console.WriteLine($"DeepCopy {deepCopySandwich}");
            Console.WriteLine();


            shallowCopySandwich.Drink.Name = "Pepsi";

            Console.WriteLine($"Original {originalSandwich}");
            Console.WriteLine($"ShallowCopy {shallowCopySandwich}");
            Console.WriteLine($"DeepCopy {deepCopySandwich}");
            Console.WriteLine();

            deepCopySandwich.Drink.Name = "Tuborg;";

            Console.WriteLine($"Original {originalSandwich}");
            Console.WriteLine($"ShallowCopy {shallowCopySandwich}");
            Console.WriteLine($"DeepCopy {deepCopySandwich}");
        }
    }
}
