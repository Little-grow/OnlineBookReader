using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal class Admin : IUser, ILoadable
    {
        public string UserName { get; set; } 
        public string Password { get; set; }
        public string Name { get; set; }
        public string? Email { get; set;}
        public bool RegularUser { get; set; }


        public Admin()
        {
            UserName = Password = Name = Email ="_";
            RegularUser = false;
        }
        public Admin(string line)
        {
            Load(line); 
        } // we assume the user will behave properly 
        public override string ToString()
        {
            return string.Join(",", UserName, Password, Name, Email, RegularUser);
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

        public void ViewProfile()
        {
            Console.WriteLine($"Name: {Name}\n" +
                $"User name: {UserName}\n" +
                $"Email: {Email}");
        }

        void AddBook()
        {
            BooksManager.AddBook();
        }

        public void LogOut()
        {
            Console.WriteLine("I wish you have token a nice experience!");
            Environment.Exit(0);
        }

        Dictionary<int, Action<Admin>> Choices = new Dictionary<int, Action<Admin>>()
        {
            { 1, (admin) => admin.ViewProfile()},
            { 2, (admin) => admin.AddBook()},
            { 3, (admin) => admin.LogOut()}
        };

        static int AdminView()
        {
            var view = new List<string>()
            {
                "view Profile",
                "add book",
                "log out"
            };
            return Helper.ShowReadMenu(view);
        }

        public void HandleAdminChoices(Admin admin)
        {
           int choice = AdminView();
           Choices[choice](admin);
        }
    }
}
