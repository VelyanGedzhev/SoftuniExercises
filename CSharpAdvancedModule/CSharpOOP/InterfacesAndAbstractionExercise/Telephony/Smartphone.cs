using System;
using System.Linq;
using Telephony.Interfaces;

namespace Telephony
{
    public class Smartphone : ICall, IBrowse
    {
        public void Browse(string url)
        {
            Console.WriteLine($"Browsing: {url}!");
        }

        public void Call(string phoneNumber)
        {
            Console.WriteLine($"Calling... {phoneNumber}");
        }
    }
}
