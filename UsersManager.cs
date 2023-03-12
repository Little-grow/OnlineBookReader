using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal static class UsersManager
    {

        static List<T> LoadDatabase<T>(string fileName) where T : ILoadable, new()
        {
            var lines = Helper.ReadFileLines(fileName);
            var users = new List<T>();
            foreach (var line in lines)
            {
                var user = new T();
                user.Load(line);
                users.Add(user);
            }
            return users;
        }

        public static void UpdateDatabase(Customer customer) 
        {
            string line = customer.ToString();
            var lines = new List<string>();
            lines.Add(line);
            Helper.WriteFileLines("Customers.txt",lines);
        } 

        public static void Login(bool RegularUser, string userName, string PassWord)
        {
            if (RegularUser)
            {
                List<Customer> customers = LoadDatabase<Customer>("Customers.txt"); // slow method but keep it now 
                var Foundedcustomer = customers.Find(customer => customer.UserName == userName && customer.Password == PassWord);
                if (Foundedcustomer is null)
                {
                    Console.WriteLine("This User isn't Signed in, You can sign up");
                    return;
                }
                else
                {
                    //Show Customer View 
                }
            }
            else
            {
                List<Admin> admins = LoadDatabase<Admin>("Admins.txt");
                var FoundedAdmin = admins.Find(admin => admin.UserName == userName && admin.Password == PassWord);
                if (FoundedAdmin is null)
                {
                    Console.WriteLine("This Admin isn't in the system, Try again!");
                    return;
                }
                else
                {
                    FoundedAdmin.HandleAdminChoices(FoundedAdmin);
                }
            }
        }

        public static void SignUp()
        {
            string line = "";
            Console.WriteLine("Enter user name");
            line += Console.ReadLine();
            Console.WriteLine("Enter passowrd");
            line += ", " + Console.ReadLine();
            Console.WriteLine("Enter name: ");
            line += "," + Console.ReadLine();
            Console.WriteLine("Enter email: ");
            line += ", " + Console.ReadLine();
            line += ", true";
            Customer customer = new Customer(line);
            UsersManager.UpdateDatabase(customer);
            customer.HandleCustomerChoices(customer);
        }
    }
}

