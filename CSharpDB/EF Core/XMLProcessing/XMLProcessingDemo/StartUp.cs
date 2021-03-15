using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XMLProcessingDemo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            //CreateNewXmlFile();

            //XDocument document = XDocument.Load("../../../bgWiki.xml");

            //var articles = document.Root.Elements().Where(x => x.Element("abstract").Value.Contains("програмис") || x.Element("abstract").Value.Contains("програмир"));

            //foreach (var article in articles)
            //{
            //    Console.WriteLine(article.Element("title").Value
            //        .Replace("Уикипедия: ", string.Empty));
            //}


            var serializer = new XmlSerializer(typeof(Article[]), new XmlRootAttribute("feed"));
            IEnumerable<Article> articles = (Article[])serializer.Deserialize(File.OpenRead("../../../bgWiki.xml"));


            foreach (var article in articles.Where(x => x.Abstract.Contains("програмис")
            || x.Abstract.Contains("програмир")))
            {
                Console.WriteLine(article.Title.Replace("Уикипедия: ", string.Empty));
            }
        }

        private static void CreateNewXmlFile()
        {
            XDocument document = new XDocument();
            var root = new XElement("library");
            document.Add(root);

            for (int i = 0; i < 100; i++)
            {
                var book = new XElement("book");
                root.Add(book);
                book.Add(new XElement("title", i.ToString()));
                book.Add(new XElement("price", i / 100.0));
            }

            document.Save("newTestXml.xml");
        }
    }
}
