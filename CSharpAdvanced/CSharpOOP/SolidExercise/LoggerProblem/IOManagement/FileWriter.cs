using LoggerProblem.IOManagement.Interfaces;
using System;
using System.IO;

namespace LoggerProblem.IOManagement
{
    public class FileWriter : IWriter
    {
        public FileWriter(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }
        public void Write(string text)
        {
            File.WriteAllText(FilePath, text);
        }

        public void WriteLine(string text)
        {
            File.AppendAllText(FilePath, text + Environment.NewLine);
        }
    }
}
