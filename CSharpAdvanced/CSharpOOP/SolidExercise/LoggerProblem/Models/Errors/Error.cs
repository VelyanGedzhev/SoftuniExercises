using LoggerProblem.Models.Enumerations;
using LoggerProblem.Models.Interfaces;
using System;

namespace LoggerProblem.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level)
        {
            DateTime = dateTime;
            Message = message;
            Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }

    }
}
