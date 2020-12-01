using System;

namespace CompositePattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var singleGift = new SingleGift(10m, "Toy");

            Console.WriteLine($"Total price: {singleGift.CalculateTotalPrice()}");

            var compositeGift = new Composite(0, "Root Box");
            var anotherSingleGift = new SingleGift(50m, "Wows");
            var otherSingleGift = new SingleGift(80m, "Wows Premium account");

            compositeGift.Add(anotherSingleGift);
            compositeGift.Add(otherSingleGift);

            Console.WriteLine($"{compositeGift.Name} total price: {compositeGift.CalculateTotalPrice()}");
        }
    }
}
