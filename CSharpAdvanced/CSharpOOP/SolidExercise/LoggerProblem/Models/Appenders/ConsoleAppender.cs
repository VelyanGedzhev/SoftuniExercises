using LoggerProblem.Common;
using LoggerProblem.IOManagement;
using LoggerProblem.IOManagement.Interfaces;
using LoggerProblem.Models.Enumerations;
using LoggerProblem.Models.Interfaces;
using System;

namespace LoggerProblem.Models.Appenders
{
    public class ConsoleAppender : Appender
    {
        private readonly IWriter writer;

        public ConsoleAppender(ILayout layout, Level level)
            : base(layout, level)
        {
            writer = new ConsoleWriter();
        }
        public override void Append(IError error)
        {
            string format = Layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedString = string.Format(dateTime.ToString(GlobalConstants.DATE_TIME_FORMAT),
                level.ToString(), message);

            writer.WriteLine(formattedString);
            messagesAppended++;
        }
    }
}
