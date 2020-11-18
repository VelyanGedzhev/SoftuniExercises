using LoggerProblem.IOManagement;
using LoggerProblem.IOManagement.Interfaces;
using LoggerProblem.Models.Enumerations;
using LoggerProblem.Models.Interfaces;

namespace LoggerProblem.Models.Appenders
{
    public class FileAppender : Appender
    {
        private readonly IWriter writer;
        public FileAppender(ILayout layout, Level level, IFile file)
            : base(layout, level)
        {
            File = file;
            writer = new FileWriter(File.Path);
        }

        public IFile File { get; }
        public override void Append(IError error)
        {
            string formattedMessage = File.Write(Layout, error);
            writer.WriteLine(formattedMessage);
            messagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {File.Size}";
        }
    }
}
