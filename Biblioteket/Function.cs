using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket
{
    class Function
    {
        public List<Book> createList()
        {
            var books = new List<Book>();
            books.Add(new Roman { Title = "Roman1", Author = "Author1", AvailableBooks = 3, DateOfRelease = "21/9-18", Language = "Svenska" });
            books.Add(new Roman { Title = "Roman2", Author = "Author2", AvailableBooks = 4, DateOfRelease = "20/6-18", Language = "English" });
            books.Add(new Child { Title = "Child1", Author = "Author3", AvailableBooks = 0, AgeRating = 5, hasPictures = true });
            books.Add(new Child { Title = "Child2", Author = "Author4", AvailableBooks = 2, AgeRating = 8, hasPictures = false });
            books.Add(new Fact { Title = "Fact1", Author = "Author5", AvailableBooks = 3, Subject = "Geofrafi" });
            books.Add(new Fact { Title = "Fact2", Author = "Author6", AvailableBooks = 4, Subject = "Teknik" });
            return books;
        }

        public void showList(List<Book> bookList)
        {
            string description = "";
            int numberOfBooks = 0;
            foreach(var Book in bookList)
            {
                if(Book is Roman)
                {
                    description = " Utgivningdatum: " + ((Roman)Book).DateOfRelease + " Språk: " + ((Roman)Book).Language;
                    numberOfBooks = numberOfBooks + Book.AvailableBooks;
                }
                if(Book is Child)
                {
                    description = " Ålder: " + ((Child)Book).AgeRating + " Bilderbok: " + ((Child)Book).hasPictures;
                    numberOfBooks = numberOfBooks + Book.AvailableBooks;
                }
                if(Book is Fact)
                {
                    description = " Ämne: " + ((Fact)Book).Subject;
                    numberOfBooks = numberOfBooks + Book.AvailableBooks;
                }
                Console.WriteLine("Författare: " + Book.Author + " Tillgängliga böcker: " + Book.AvailableBooks + description);
            }
            Console.WriteLine("Antal tillgängliga böcker: " + numberOfBooks);
            BorrowBook(bookList);
        }

        public List<Book> BorrowBook(List<Book> bookList)
        {
            ConsoleKeyInfo letter = Console.ReadKey();
            if (letter.KeyChar == 'l')
            {
                Console.WriteLine("Välj bok att låna");
                Console.ReadKey();
                if(letter.KeyChar == '1')
                {
                    bookList[0].AvailableBooks--;
                    showList(bookList);
                    return bookList;
                }
            }
            if (letter.KeyChar == '1')
            {
                bookList[0].AvailableBooks--;
                showList(bookList);
                return bookList;
            }
            else
            {
                showList(bookList);
                return bookList;
            }
        }
    }
}
