using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket
{
    class Function
    {
        //Funktion som skapar listan med böcker
        public List<Book> createList()
        {
            var books = new List<Book>();
            books.Add(new Roman { Title = "Roman1", Author = "Author1", AvailableBooks = 3, Borrowed = 0, DateOfRelease = "21/9-18", Language = "Svenska" });
            books.Add(new Roman { Title = "Roman2", Author = "Author2", AvailableBooks = 4, Borrowed = 0, DateOfRelease = "20/6-18", Language = "English" });
            books.Add(new Child { Title = "Child1", Author = "Author3", AvailableBooks = 0, Borrowed = 0, AgeRating = 5, hasPictures = true });
            books.Add(new Child { Title = "Child2", Author = "Author4", AvailableBooks = 2, Borrowed = 0, AgeRating = 8, hasPictures = false });
            books.Add(new Fact { Title = "Fact1", Author = "Author5", AvailableBooks = 3, Borrowed = 0, Subject = "Geofrafi" });
            books.Add(new Fact { Title = "Fact2", Author = "Author6", AvailableBooks = 4, Borrowed = 0, Subject = "Teknik" });
            return books;
        }
        //Funktion som visar boklistan
        public void showList(List<Book> bookList)
        {
            string description = "";
            int numberOfBooks = 0;
            int bookNumber = 0;
            int numberOfBorrowedBooks = 0;
            foreach (var Book in bookList)
            {
                if(Book is Roman)
                {
                    description = " Utgivningdatum: " + ((Roman)Book).DateOfRelease + " Språk: " + ((Roman)Book).Language;
                    numberOfBooks = numberOfBooks + Book.AvailableBooks;
                    numberOfBorrowedBooks = numberOfBorrowedBooks + Book.Borrowed;
                }
                if(Book is Child)
                {
                    description = " Ålder: " + ((Child)Book).AgeRating + " Bilderbok: " + ((Child)Book).hasPictures;
                    numberOfBooks = numberOfBooks + Book.AvailableBooks;
                    numberOfBorrowedBooks = numberOfBorrowedBooks + Book.Borrowed;
                }
                if(Book is Fact)
                {
                    description = " Ämne: " + ((Fact)Book).Subject;
                    numberOfBooks = numberOfBooks + Book.AvailableBooks;
                    numberOfBorrowedBooks = numberOfBorrowedBooks + Book.Borrowed;
                }
                bookNumber++;
                Console.WriteLine(bookNumber + ". Titel: " + Book.Title + " Författare: " + Book.Author + " Tillgängliga böcker: " + Book.AvailableBooks + description + "\r\n");
            }
            Console.WriteLine("Antal tillgängliga böcker: " + numberOfBooks);
            Console.WriteLine("Antal utlånade böcker: " + numberOfBorrowedBooks + "\r\n");
            Console.WriteLine("Tryck på L för att låna en bok\r\nTryck på R för att lämna tillbaka en bok");
            alternative(bookList);
        }
        //Funktion för att välja om man ska lämna tillbaka eller låna en bok
        public List<Book> alternative(List<Book> bookList)
        {
            ConsoleKeyInfo letter = Console.ReadKey();
            if (letter.KeyChar == 'r')
            {
                ReturnBook(bookList);
                return bookList;
            }
            if (letter.KeyChar == 'l')
            {
                BorrowBook(bookList);
                return bookList;
            }
            else
            {
                showList(bookList);
                return bookList;
            }
        }
        //Funktion för att låna en bok
        public List<Book> BorrowBook(List<Book> bookList)
        {
                Console.WriteLine("\r\nVälj bok att låna (1-6)");
                ConsoleKeyInfo letter = Console.ReadKey();
                if(bookList[int.Parse(letter.KeyChar.ToString()) - 1].AvailableBooks == 0)
                {
                    Console.WriteLine("\r\nDu kan inte låna den boken!\r\n");
                showList(bookList);
                    return bookList;
                }
                else
                {
                    Console.WriteLine("\r\nDu lånade: " + bookList[int.Parse(letter.KeyChar.ToString()) - 1].Title + "\r\n");
                    bookList[int.Parse(letter.KeyChar.ToString()) - 1].AvailableBooks--;
                    bookList[int.Parse(letter.KeyChar.ToString()) - 1].Borrowed++;
                    showList(bookList);
                    return bookList;
                }
        }
        //Funktion för att lämna tillbaka en bok
        public List<Book> ReturnBook(List<Book> bookList)
        {
            Console.WriteLine("\r\nVälj bok att lämna tillbaka (1-6)");
            ConsoleKeyInfo letter = Console.ReadKey();
            if (bookList[int.Parse(letter.KeyChar.ToString()) - 1].Borrowed == 0)
            {
                Console.WriteLine("\r\nAlla exemplar är redan återlämnade!\r\n");
                showList(bookList);
                return bookList;
            }
            else
            {
                Console.WriteLine("\r\nDu lämnade tillbaka: " + bookList[int.Parse(letter.KeyChar.ToString()) - 1].Title + "\r\n");
                bookList[int.Parse(letter.KeyChar.ToString()) - 1].AvailableBooks++;
                bookList[int.Parse(letter.KeyChar.ToString()) - 1].Borrowed--;
                showList(bookList);
                return bookList;
            }
        }
    }
}
