using DummyGame.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DummyGame.IO
{
    class ConsoleReader : IReader
    {
        public void Read()
        {
            Console.ReadLine();
        }
    }
}
