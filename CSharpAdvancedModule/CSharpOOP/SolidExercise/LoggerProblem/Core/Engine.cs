using LoggerProblem.Common;
using LoggerProblem.Core.Interfaces;
using LoggerProblem.Factories;
using LoggerProblem.IOManagement.Interfaces;
using LoggerProblem.Models.Enumerations;
using LoggerProblem.Models.Errors;
using LoggerProblem.Models.Interfaces;
using System;
using System.Globalization;

namespace LoggerProblem.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ILogger logger, IReader reader, IWriter writer)
        {
            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command = string.Empty;

            while ((command = this.reader.ReadLine()) != "END")
            {
                string[] errorArgs = command
                    .Split("|");

                string levelStr = errorArgs[0];
                string dateTimeStr = errorArgs[1];
                string message = errorArgs[2];

                bool isLevelValid = Enum.TryParse(typeof(Level), levelStr, true, out object levelObj);

                if (!isLevelValid)
                {
                    this.writer.WriteLine(GlobalConstants.INVALID_LEVEL_TYPE);
                    continue;
                }

                Level level = (Level)levelObj;

                bool isDateTimeValid = DateTime.TryParseExact(dateTimeStr, GlobalConstants.DATE_TIME_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);

                if (!isDateTimeValid)
                {
                    this.writer.WriteLine(GlobalConstants.INVALID_DATETIME_TYPE);
                }

                IError error = new Error(dateTime, message, level);

                this.logger.Log(error);
            }

            this.writer.WriteLine(this.logger.ToString());
        }
    }
}
