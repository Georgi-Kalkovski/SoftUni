using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Articles
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
		
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
	
    class Program
    {
        static void Main(string[] args)
        {
            int countCommands = int.Parse(Console.ReadLine());
            var articles = new List<Article>();

            for (int i = 0; i < countCommands; i++)
            {
                string[] splittedCommand = Console.ReadLine()
                .Split(", ");

                string title = splittedCommand[0];
                string content = splittedCommand[1];
                string author = splittedCommand[2];

                var article = new Article(title, content, author);

                articles.Add(article);
            }
			
            string command = Console.ReadLine();

            if (command == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
			
            if (command == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
			
            if (command == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }
    }
}
