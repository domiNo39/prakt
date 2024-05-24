using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace BookSorter
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string inFile = "file.xml";
            string outXml = "outxml.xml";
            string outTxt = "outtxt.txt";

            XDocument inputDoc = XDocument.Load(inFile);
            var books = inputDoc.Root.Elements("Book")
                .Select(book => new Book
                {
                    Title = book.Element("Title").Value,
                    Author = book.Element("Author").Value,
                    Year = int.Parse(book.Element("Year").Value)
                })
                .ToList();

            var sortedBooks = books.OrderBy(book => book.Year).ToList();

            XDocument outputDoc = new XDocument(
                new XElement("Books",
                    sortedBooks.Select(book =>
                        new XElement("Book",
                            new XElement("Title", book.Title),
                            new XElement("Author", book.Author),
                            new XElement("Year", book.Year)
                        ))
                )
            );
            outputDoc.Save(outXml);

            using (StreamWriter writer = new StreamWriter(outTxt))
            {
                foreach (var book in sortedBooks)
                {
                    writer.WriteLine($"Title: {book.Title} Author: {book.Author} Year: {book.Year}");
                }
            }

            Console.WriteLine("Дані успішно збережені в файли sorted_books.xml та books.txt.");
            Console.ReadLine();
        }
    }

   
}

