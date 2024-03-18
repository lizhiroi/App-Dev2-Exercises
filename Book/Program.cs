using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class Book
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public int PublicationYear { get; set; }

        public Book(string title, int pages, int publicationYear)
        {
            Title = title;
            Pages = pages;
            PublicationYear = publicationYear;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();

            // Read book information from user
            while (true)
            {
                Console.Write("Name: ");
                string title = Console.ReadLine();
                if (string.IsNullOrEmpty(title))
                    break;

                Console.Write("Pages: ");
                int pages = int.Parse(Console.ReadLine());

                Console.Write("Publication year: ");
                int publicationYear = int.Parse(Console.ReadLine());

                books.Add(new Book(title, pages, publicationYear));
            }

            // Write book information to CSV file
            WriteToCSV(books);

            // Read user input for printing information
            Console.WriteLine("What information will be printed?");
            string input = Console.ReadLine();

            // Print information based on user input
            if (input.ToLower() == "everything")
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title}, {book.Pages} pages, {book.PublicationYear}");
                }
            }
            else if (input.ToLower() == "title")
            {
                foreach (var book in books)
                {
                    Console.WriteLine(book.Title);
                }
            }

            Console.ReadLine();
        }

        static void WriteToCSV(List<Book> books)
        {
            using (StreamWriter writer = new StreamWriter("books.csv"))
            {
                writer.WriteLine("Title,Pages,PublicationYear");

                foreach (var book in books)
                {
                    writer.WriteLine($"{book.Title},{book.Pages},{book.PublicationYear}");
                }
            }
        }
    }
}