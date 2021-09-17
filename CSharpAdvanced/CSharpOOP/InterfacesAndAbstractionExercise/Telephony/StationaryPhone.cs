using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Interfaces;

namespace Telephony
{
    public class StationaryPhone : ICall
    {
        public void Browse(string url)
        {
           
        }

        public void Call(string phoneNumber)
        {
            Console.WriteLine($"Dialing... {phoneNumber}");

        }
    }
}
