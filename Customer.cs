using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal class Customer : IUser, ILoadable
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public bool  RegularUser { get; set; }
        List<Session> sessions = new List<Session>();

        public Customer()
        {
            UserName = Password = Name = Email = "_";
            RegularUser = true;
        }
        public Customer(string line)
        {
            Load(line);
        }
        public override string ToString()
        {
            string customer = string.Join(',', UserName, Password, Name, Email, RegularUser);
            for (int i = 0; i < sessions.Count; i++)
            {
                customer += sessions[i].ToString();
            }
            return customer;
        }
        public void Load(string line)
        {
            List<string> information = new List<string>(line.Split(','));
            UserName = information[0];
            Password = information[1];
            Name = information[2];
            Email = information[3];
            RegularUser = bool.Parse(information[4]);
        }

        public void Login()
        {
            bool regularUser = true;

            Console.WriteLine("Enter user name: ");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();

            UsersManager.Login(regularUser, userName, password);
        }
        public void ViewProfile()
        {
            Console.WriteLine($"Name: {Name}\n" +
               $"User name: {UserName}\n" +
               $"Email: {Email}");
        }

        public void List_SelectFromReadingHistory()
        {
            if (sessions.Count <= 0)
            {
                Console.WriteLine("No previous seesions.");
                return;
            }
            Helper.ShowReadMenu(sessions.Select(session => session.ToString()).ToList());
            Console.WriteLine("Which seesion to open? ");
            int choice = Helper.ReadInt(1, sessions.Count);
            Console.WriteLine($"{sessions[choice].curPage}:/{sessions[choice].SeesionBook.PagesNumber}");
            Console.WriteLine($"{sessions[choice].SeesionBook.Title}");
        }

        public void List_SelectFromAvailableBooks()
        {
            int count = BooksManager.books.Count;
            if (count <= 0)
            {
                Console.WriteLine("No books available now");
                return;
            }
            BooksManager.ShowAvailableBooks();
            Console.WriteLine("\nWhich book to read? ");
            int choice = Helper.ReadInt(1,count);
            Book book = BooksManager.books[choice - 1];
            Session session = new Session(book);
            sessions.Add(session);
            session.Naviagtion();
        }

        public void LogOut()
        {
            Console.WriteLine("wish you nice day");
            UsersManager.UpdateDatabase(this); // this customr to add the new seesions 
            Environment.Exit(0);
        }

        Dictionary<int, Action<Customer>> Choices = new Dictionary<int, Action<Customer>>()
        {
            {1, (customer) => customer.ViewProfile() },
            {2, (customer) => customer.List_SelectFromReadingHistory()},
            {3, (customer) => customer.List_SelectFromAvailableBooks() },
            {4, (customer) => customer.LogOut() }
        };
        
        public static int CustomerView()
        {
            var view = new List<string>()
            {
                "view profile", 
                "List and select from Reading History", 
                "List and select from available books", 
                "log out"
            };
            return Helper.ShowReadMenu(view);
        }

        public void HandleCustomerChoices(Customer customer)
        {
            int choice = CustomerView();
            Choices[choice](customer);
        }
    }
}
