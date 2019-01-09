using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Biblioteket
{
    class Function
    {
        //Funktion som skapar listan med böcker
        public static List<Book> createList()
        {
            var books = new List<Book>();
            books.Add(new Roman { Title = "Roman1", Author = "Author1", AvailableBooks = 3, Borrowed = 0, DateOfRelease = new DateTime (2018, 09, 21), Language = "Svenska" });
            books.Add(new Roman { Title = "Roman2", Author = "Author2", AvailableBooks = 4, Borrowed = 0, DateOfRelease = new DateTime (2018, 06, 20), Language = "English" });
            books.Add(new Child { Title = "Child1", Author = "Author3", AvailableBooks = 0, Borrowed = 0, AgeRating = 5, hasPictures = true });
            books.Add(new Child { Title = "Child2", Author = "Author4", AvailableBooks = 2, Borrowed = 0, AgeRating = 8, hasPictures = false });
            books.Add(new Fact { Title = "Fact1", Author = "Author5", AvailableBooks = 3, Borrowed = 0, Subject = "Geofrafi" });
            books.Add(new Fact { Title = "Fact2", Author = "Author6", AvailableBooks = 4, Borrowed = 0, Subject = "Teknik" });
            return books;
        }
        //Funktion som visar boklistan
        public static void showList(List<Book> bookList)
        {
            string description = "";
            int numberOfBooks = 0; //Räkna antal böcker i biblioteket
            int bookNumber = 0; //Bokens placering i listan
            int numberOfBorrowedBooks = 0; //Räkna antal lånade böcker från biblioteket
            foreach (var Book in bookList) //Kollar vilken typ av bok det är och ger den rätt beskrivning
            {
                if(Book is Roman)
                {
                    description = " Utgivningdatum: " + ((Roman)Book).DateOfRelease + " Språk: " + ((Roman)Book).Language;
                }
                if(Book is Child)
                {
                    description = " Ålder: " + ((Child)Book).AgeRating + " Bilderbok: " + ((Child)Book).hasPictures;
                }
                if(Book is Fact)
                {
                    description = " Ämne: " + ((Fact)Book).Subject;
                }
                numberOfBooks = numberOfBooks + Book.AvailableBooks;
                numberOfBorrowedBooks = numberOfBorrowedBooks + Book.Borrowed;
                bookNumber++;
                Console.WriteLine(bookNumber + ". Titel: " + Book.Title + " Författare: " + Book.Author + " Tillgängliga böcker: " + Book.AvailableBooks + description + "\r\n"); //Kan förenklas
            }
            Console.WriteLine("Antal tillgängliga böcker: " + numberOfBooks + "\r\n" + "Antal utlånade böcker: " + numberOfBorrowedBooks + "\r\n\r\nTryck på L för att låna en bok\r\nTryck på R för att lämna tillbaka en bok");
            alternative(bookList);
        }
        //Funktion för att välja om man ska lämna tillbaka eller låna en bok (Gör om till switch?)
        public static List<Book> alternative(List<Book> bookList)
        {
            ConsoleKeyInfo letter = Console.ReadKey();
            if (letter.KeyChar == 'r')
            {
                ReturnBook(bookList); //Kör funktionen för att lämna tillbaka en bok
            }
            if (letter.KeyChar == 'l')
            {
                BorrowBook(bookList); //Kör funktionen för att låna en bok
            }
            else
            {
                showList(bookList);
            }
            return bookList;
        }
        //Funktion för att låna en bok
        public static List<Book> BorrowBook(List<Book> bookList)
        {
                Console.WriteLine("\r\nVälj bok att låna (1-6)");
                ConsoleKeyInfo letter = Console.ReadKey();
                if(bookList[int.Parse(letter.KeyChar.ToString()) - 1].AvailableBooks == 0)
                {
                    Console.WriteLine("\r\nDu kan inte låna den boken!\r\n");
                }
                else
                {
                    Console.WriteLine("\r\nDu lånade: " + bookList[int.Parse(letter.KeyChar.ToString()) - 1].Title + "\r\n");
                    bookList[int.Parse(letter.KeyChar.ToString()) - 1].AvailableBooks--;
                    bookList[int.Parse(letter.KeyChar.ToString()) - 1].Borrowed++;
                }
                SaveData(bookList);
                showList(bookList);
                return bookList;
        }           
        //Funktion för att lämna tillbaka en bok
        public static List<Book> ReturnBook(List<Book> bookList)
        {
            Console.WriteLine("\r\nVälj bok att lämna tillbaka (1-6)");
            ConsoleKeyInfo letter = Console.ReadKey();
            if (bookList[int.Parse(letter.KeyChar.ToString()) - 1].Borrowed == 0)
            {
                Console.WriteLine("\r\nAlla exemplar är redan återlämnade!\r\n");
            }
            else
            {
                Console.WriteLine("\r\nDu lämnade tillbaka: " + bookList[int.Parse(letter.KeyChar.ToString()) - 1].Title + "\r\n");
                bookList[int.Parse(letter.KeyChar.ToString()) - 1].AvailableBooks++;
                bookList[int.Parse(letter.KeyChar.ToString()) - 1].Borrowed--;
            }
            SaveData(bookList);
            showList(bookList);
            return bookList;
        }
        //Funktion för att spara data
        public static bool SaveData(List<Book> bookList)
        {
            string fileName = "library.json";

            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(bookList.ToArray(), settings);
            System.IO.File.WriteAllText(@"..\..\storage\" + fileName, json);

            return true;
        }
        //Funktion för att hämta data
        public static List<Book> GetData()
        {
            string fileName = "library.json";
            string filepath = @"..\..\storage\" + fileName;

            List<Book> data;
            if (System.IO.File.Exists(filepath))
            {
                var settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };
                var json = System.IO.File.ReadAllText(filepath);
                data = JsonConvert.DeserializeObject<List<Book>>(json, settings);
            }
            else
            {
                data = createList();
            }
            return data;
        }
    }
}
