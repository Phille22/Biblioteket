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
            Function f = new Function();
            var bookList = f.createList();
            f.showList(bookList);
        }
    }
}
