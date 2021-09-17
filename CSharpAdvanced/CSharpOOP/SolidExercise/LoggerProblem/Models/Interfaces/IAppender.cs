using LoggerProblem.Models.Enumerations;

namespace LoggerProblem.Models.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }
        Level Level { get; }

        public void Append(IError error);
    }
}
