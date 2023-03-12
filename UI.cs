using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal static class UI
    {
        public static void Run()
        {
            List<string> menu = new List<string>() { "login", "sign up" };
            int choice = Helper.ShowReadMenu(menu);
            if (choice == 1)
            {
                Console.WriteLine("enter true for user, false for admin");
                bool regularUser = bool.Parse(Console.ReadLine());
                Console.WriteLine("Enter user name");
                string userName = Console.ReadLine();
                Console.WriteLine("Enter password");
                string password = Console.ReadLine();
                UsersManager.Login(regularUser, userName, password);
            }
            else
            {
                UsersManager.SignUp();
            }
        }
         
        public static void Main(string[] args)
        {
            Run();
        }
    }
}
