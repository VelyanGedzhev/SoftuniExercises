using LoggerProblem.Common;
using LoggerProblem.Models.Enumerations;
using LoggerProblem.Models.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace LoggerProblem.Models.CustomFiles
{
    public class LogFile : IFile
    {
        private readonly IPathManager pathManager;

        public LogFile(IPathManager pathManager)
        {
            this.pathManager = pathManager;
            this.pathManager.EnsureDirectoryAndFileExists();
        }

        public string Path => pathManager.CurrentFilePath;

        public long Size => CalculateFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;


            string formattedMessage = string.Format(format,
                dateTime.ToString(GlobalConstants.DATE_TIME_FORMAT),
                level.ToString(),
                message);

            return formattedMessage;
        }
        private long CalculateFileSize()
        {
            string fileText = File.ReadAllText(Path);

            return fileText.ToCharArray()
                .Where(c => Char.IsLetter(c))
                .Sum(c => c);
        }
    }
}
