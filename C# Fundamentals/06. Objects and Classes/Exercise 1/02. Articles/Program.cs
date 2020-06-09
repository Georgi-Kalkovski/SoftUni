using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Articles
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
		
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
		
        public void Edit(string newContent)
        {
            this.Content = newContent;
        }
		
        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }
		
        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }
		
        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
	
    class Program
    {
        static void Main(string[] args)
        {
            string[] articles = Console.ReadLine()
                .Split(", ");

            string title = articles[0];
            string content = articles[1];
            string author = articles[2];

            Article article = new Article(title, content, author)
            {
                Title = title,
                Content = content,
                Author = author
            };

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                List<string> commands = Console.ReadLine()
                    .Split(": ")
                    .ToList();

                string command = commands[0];

                if (command == "Edit")
                {
                    string newContent = commands[1];
                    article.Edit(newContent);
                }
				
                if (command == "ChangeAuthor")
                {
                    string newAuthor = commands[1];
                    article.ChangeAuthor(newAuthor);
                }
				
                if (command == "Rename")
                {
                    string newTitle = commands[1];
                    article.Rename(newTitle);
                }
            }
			
            Console.WriteLine(article);
        }
    }
}
