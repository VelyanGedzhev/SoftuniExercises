using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProblem.Models.Interfaces
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        public void Log(IError error);
    }
}
