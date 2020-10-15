using System;

namespace _5._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = Console.ReadLine();
            string correctPassword = "";
            int counter = 0;

            for(int i = userName.Length - 1; i >= 0; i--)
            {
                correctPassword += userName[i];
            }
            while (password != correctPassword)
            {

                counter++;
                if(counter == 4)
                {
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                password = Console.ReadLine();
                
            }
            if(password == correctPassword)
            {
                Console.WriteLine($"User {userName} logged in.");
            }
            else
            {
                Console.WriteLine($"User {userName} blocked!");
            }

        }
    }
}
