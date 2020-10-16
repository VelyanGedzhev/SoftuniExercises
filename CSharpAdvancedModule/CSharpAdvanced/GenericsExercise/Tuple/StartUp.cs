using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstTokens = Console.ReadLine()
                .Split();

            string fullName = firstTokens[0] + " " + firstTokens[1];
            string location = firstTokens[2];
            Tuple<string, string> person = new Tuple<string, string>(fullName, location);


            string[] secondTokens = Console.ReadLine()
                .Split();

            string name = secondTokens[0];
            int litersBeer = int.Parse(secondTokens[1]);
            Tuple<string, int> beers = new Tuple<string, int>(name, litersBeer);
            
            string[] thirdTokens = Console.ReadLine()
                .Split();

            int firstNum = int.Parse(thirdTokens[0]);
            double secondNum = double.Parse(thirdTokens[1]);
            Tuple<int, double> numbers = new Tuple<int, double>(firstNum, secondNum);

            Console.WriteLine(person);
            Console.WriteLine(beers);
            Console.WriteLine(numbers);
            
            
        }
    }
}
