using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < count; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Article article = new Article(data);
                articles.Add(article);
            }
            List<Article> sortedList = new List<Article>();
            string command = Console.ReadLine();

            if (command == "title")
            {
                sortedList = articles.OrderBy(x => x.Title).ToList();
            }
            else if (command == "content")
            {
                sortedList = articles.OrderBy(x => x.Content).ToList();
            }
            else if (command == "author")
            {
                sortedList = articles.OrderBy(x => x.Author).ToList();
            }
            Console.WriteLine(String.Join(Environment.NewLine, sortedList));
        }
    }
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string[] data)
        {
            this.Title = data[0];
            this.Content = data[1];
            this.Author = data[2];
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
