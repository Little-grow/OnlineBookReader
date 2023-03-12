using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal class Session
    {
        public DateTime DateTime { get; set; }
        public Book SeesionBook { get; set; }
        public int curPage { get; set; } = 1;

        public Session(Book book)
        {
            DateTime = DateTime.Now;
            SeesionBook = book;
        }

        public override string ToString()
        {
            return $"{SeesionBook}  {DateTime}";
        }

        public void Naviagtion()
        {
            List<string> menu = new List<string>()
            {
                "Next page ",
                "Previous page",
                "Stop Reading"
            };
            int choice = Helper.ShowReadMenu(menu);
            if (choice == 1 && curPage+1 < SeesionBook.pages.Count)
                curPage++;
            else if (choice == 2 && curPage - 1 > 0)
                curPage--;
            else
            {
                DateTime = DateTime.Now;
                Customer.CustomerView();
            }
        }
    }
}
