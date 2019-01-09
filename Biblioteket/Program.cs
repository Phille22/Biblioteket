using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> Books = Function.GetData();
            Function.showList(Books);
        }
    }
}
