using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int PagesNumber { get; set; }
        public List<Page> pages = new List<Page>();

        public Book()
        {
            ISBN = Title = AuthorName = "_";
            PagesNumber = 0;
        }

        public Book(string line)
        {
            List<string> information = new List<string>(line.Split(','));
            ISBN = information[0];
            Title = information[1];
            AuthorName = information[2];
            PagesNumber = int.Parse(information[3]);

            for (int i = 0; i < PagesNumber; i++)
            {
                pages[i].Title = information[4 + i];
            }
        }

        public override string ToString()
        {
            string book = string.Join(",", ISBN, Title, AuthorName, PagesNumber);
            for (int i = 0; i < pages.Count(); i++)
            {
                book += ", " + pages[i].ToString();
            }
            return book;
        }
        
        public void PrintBook()
        {
            Console.WriteLine($"{Title}");
        }
    }
}

