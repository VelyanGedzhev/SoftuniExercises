using LoggerProblem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProblem.Models.Layouts
{
    class XmlLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine("<log>")
                .AppendLine("\t<date>{0}</date>")
                .AppendLine("\t<level>{1}</level>")
                .AppendLine("\t<mesasge>{2}</message>")
                .AppendLine("</log>");

            return sb.ToString();

        }
    }
}
