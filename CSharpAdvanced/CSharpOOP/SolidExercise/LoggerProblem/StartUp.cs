using LoggerProblem.Common;
using LoggerProblem.Core;
using LoggerProblem.Core.Interfaces;
using LoggerProblem.Factories;
using LoggerProblem.IOManagement;
using LoggerProblem.IOManagement.Interfaces;
using LoggerProblem.Models;
using LoggerProblem.Models.CustomFiles;
using LoggerProblem.Models.Enumerations;
using LoggerProblem.Models.Interfaces;
using LoggerProblem.Models.PathManagement;
using System;
using System.Collections.Generic;

namespace LoggerProblem
{
    public class StartUp
    {


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IPathManager pathManager = new PathManager("logs", "logs.txt");
            IFile file = new LogFile(pathManager);

            ILogger logger = SetUpLogger(n, writer, reader, file, layoutFactory, appenderFactory);

            IEngine engine = new Engine(logger, reader, writer);
            engine.Run();
        }

        private static ILogger SetUpLogger(int appendersCount, IWriter writer, IReader reader, IFile file, LayoutFactory layoutFactory, AppenderFactory appenderFactory)
        {
           ICollection<IAppender> appenders = new HashSet<IAppender>();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersArgs = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string appenderType = appendersArgs[0];
                string layoutType = appendersArgs[1];

                bool hasError = false;

                Level level = ParseLevel(appendersArgs, writer, ref hasError);

                if (hasError)
                {
                    continue;
                }
                try
                {
                    ILayout layout = layoutFactory.CreateLayout(layoutType);
                    IAppender appender = appenderFactory.CreatAppender(appenderType, layout, level, file);

                    appenders.Add(appender);
                }
                catch (InvalidOperationException ioe)
                {

                    Console.WriteLine(ioe.Message);
                }
            }
            ILogger logger = new Logger(appenders);

            return logger;
        }

        private static Level ParseLevel(string[] levelString, IWriter writer, ref bool hasError)
        {
            Level appenderLevel = Level.INFO;

            if (levelString.Length == 3)
            {

                bool isEnumValid = Enum.TryParse(typeof(Level), levelString[2], true, out object enumParsed);

                if (!isEnumValid)
                {
                    writer.WriteLine(GlobalConstants.INVALID_LEVEL_TYPE);
                    hasError = true;
                }
                appenderLevel = (Level)enumParsed;
            }
            return appenderLevel;
        }
    }
}
