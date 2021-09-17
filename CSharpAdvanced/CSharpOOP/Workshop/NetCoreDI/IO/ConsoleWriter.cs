using DummyGame.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DummyGame.IO
{
    class ConsoleWriter : IWriter
    {
        public void Write(string s)
        {
            Console.WriteLine(s);
        }
    }
}
