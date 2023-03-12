using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal static class BooksManager
    {
        public static List<Book> books = new List<Book>();

        public static void AddBook()
        {
            var newBook = new Book();
            Console.WriteLine("Enter ISBN");
            newBook.ISBN = Console.ReadLine();

            Console.WriteLine("Enter Title");
            newBook.Title = Console.ReadLine();

            Console.WriteLine("Enter Author name");
            newBook.AuthorName = Console.ReadLine();

            Console.WriteLine("Enter How many pages: ");
            newBook.PagesNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < newBook.PagesNumber; i++)
            {
                Console.WriteLine("Enter page #" + i + 1);
                newBook.pages[i].Title = Console.ReadLine();
            }
            books.Add(newBook);
            UpdateDataBase(newBook);
        }
        public static int ShowAvailableBooks()
        {
            loadDatabase();
            Console.WriteLine("Our Current Book Collection: ");
            for (int i = 0; i < books.Count; i++)
            {
                Console.Write(i + 1);
                books[i].PrintBook();
            }
            return books.Count;
        }
        public static void loadDatabase()
        {
            List<string> lines = Helper.ReadFileLines("Books.txt");
            foreach (var line in lines)
            {
                Book book = new Book(line);
                books.Add(book);
            }
        }

        static void UpdateDataBase(Book book)
        {
            string line = book.ToString();
            List<string> lines = new List<string>();
            lines.Add(line);
            Helper.WriteFileLines("books.txt", lines);
        } // the addBook method use it internally and the admin use the AddBook method as a black box
    }
}
