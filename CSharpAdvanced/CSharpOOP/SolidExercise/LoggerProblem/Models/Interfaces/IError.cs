using LoggerProblem.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProblem.Models.Interfaces
{
    public interface IError
    {
        public DateTime DateTime { get; }
        public string Message { get; }
        public Level Level { get; }
    }
}
