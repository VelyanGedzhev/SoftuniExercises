using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLProcessingDemo
{
    [XmlType("doc")]
    public class Article
    {
        [XmlElement("abstract")]
        public string Abstract { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }
    }
}
