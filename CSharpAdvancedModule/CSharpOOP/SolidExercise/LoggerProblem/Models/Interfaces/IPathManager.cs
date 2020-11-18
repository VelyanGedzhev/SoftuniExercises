using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProblem.Models.Interfaces
{
    public interface IPathManager
    {
        public string CurrentDirectoryPath { get; }
        public string CurrentFilePath { get; }

        public string GetCurrentPath();
        public void EnsureDirectoryAndFileExists();
    }
}
