using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal interface IUser
    {
        string UserName { get; set; }
        string Password { get; set; }
        string Name { get; set; }
        string? Email { get; set; }
        bool RegularUser { get; set;}
        void ViewProfile();
        void LogOut();
    }
}
