using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// DONE: Sex olika boktitlar
// DONE: Romaner: Utgivinsdatum, språk
// DONE: Barnböcker: Åldersgräns, Bilderbok (Ja/Nej)
// DONE: Faktaböcker: Ämne (historia, teknik, etc.)
// DONE: Attribut: Gemensamma: Titel, Författare, Antal exemplar i hyllan
// DONE: Funktion för att låna ut och lämna tillbaka bok
// TODO: Bokobjekt i separat fil

namespace Biblioteket
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int AvailableBooks { get; set; }
        public int Borrowed { get; set; }
    }

    class Roman : Book
    {
        public DateTime DateOfRelease { get; set; }
        public string Language { get; set; }
    }

    class Child : Book
    {
        public int AgeRating { get; set; }
        public bool hasPictures { get; set; }
    }

    class Fact : Book
    {
        public string Subject { get; set; }
    }
}
