using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstTokens = Console.ReadLine()
                .Split();
            string fullName = firstTokens[0] + " " + firstTokens[1];
            string address = firstTokens[2];
            string town = firstTokens[3];

            Threeuple<string, string, string> person = new Threeuple<string, string, string>(fullName, address, town);


            string[] secondTokens = Console.ReadLine()
                .Split();
            string name = secondTokens[0];
            int litersBeer = int.Parse(secondTokens[1]);
            bool isDrunk = false;
            if (secondTokens[2] == "drunk")
            {
                isDrunk = true;
            }

            Threeuple<string, int, bool> beerConsumption = new Threeuple<string, int, bool>(name, litersBeer, isDrunk);


            string[] thirdTokens = Console.ReadLine()
                .Split();
            name = thirdTokens[0];
            double accountBalance = double.Parse(thirdTokens[1]);
            string bankName = thirdTokens[2];

            Threeuple<string, double, string> bankInfo = new Threeuple<string, double, string>(name, accountBalance, bankName);

            Console.WriteLine(person);
            Console.WriteLine(beerConsumption);
            Console.WriteLine(bankInfo);

        }
    }
}
