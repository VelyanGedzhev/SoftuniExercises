using LoggerProblem.Common;
using LoggerProblem.Models.Appenders;
using LoggerProblem.Models.Enumerations;
using LoggerProblem.Models.Interfaces;
using System;

namespace LoggerProblem.Factories
{
    public class AppenderFactory
    {
        public AppenderFactory()
        {

        }
        public IAppender CreatAppender(string appenderType, ILayout layout, Level level, IFile file = null)
        {
            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender" && file != null)
            {
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidOperationException(GlobalConstants.INVALID_APPENDER_TYPE);
            }
            return appender;
        }
    }
}
