using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal class Page
    {
        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
