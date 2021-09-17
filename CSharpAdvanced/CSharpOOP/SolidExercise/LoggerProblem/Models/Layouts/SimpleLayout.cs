using LoggerProblem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProblem.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
