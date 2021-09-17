using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProblem.Models.Interfaces
{
    public interface IFile
    {
        public string Path { get; }
        public long Size { get; }

        public string Write(ILayout layout, IError error);
    }
}
