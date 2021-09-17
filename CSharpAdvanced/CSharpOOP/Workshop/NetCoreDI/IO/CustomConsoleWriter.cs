using DummyGame.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DummyGame.IO
{
    class CustomConsoleWriter : IWriter
    {
        public void Write(string s)
        {
            Console.WriteLine("Custom " + s);
        }
    }
}
