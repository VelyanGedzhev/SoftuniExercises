using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class TaskInputModelXml
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        [Required]
        public string DueDate { get; set; }

        public string ExecutionType { get; set; }

        public string LabelType { get; set; }
    }
}