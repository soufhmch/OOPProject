using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Library 
    {
        public string Name { get; }
        public List<Book> Books { get; }

        private Dictionary<DateTime, ReadingRoomItem> allReadingRoom = new();

        public Library(string name)
        {
            Name = name ?? throw new ArgumentException("Bibliotheek naak kan niet null zijn.");
            Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentException("Boek kan niet null zijn");
            Books.Add(book);
        }

        public bool RemoveBook(Book book)
        {
            return Books.Remove(book);
        }

        public Book FindBookByTitleAndAuthor(string title, string author)
        {
            return Books.FirstOrDefault(b => b.Title == title && b.Author == author);
        }

        public Book FindBookByISBN(string isbn)
        {
            return Books.FirstOrDefault(b => b.ISBN == isbn);
        }

        public List<Book> FindBooksByAuthor(string author)
        {
            return Books.Where(b => b.Author == author).ToList();
        }

        public List<Book> FindBooksByProperty(Func<Book, bool> predicate)
        {
            return Books.Where(predicate).ToList();
        }
        public void AddNewsPaper()
        {
            Console.WriteLine("Wat is de naam van de krant:");
            string name = Console.ReadLine();
            Console.WriteLine("Geef de datum (DD/MM/YYYY):");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Niet geldig, geef een geldig formaat DD/MM/YYYY:");
            }
            Console.WriteLine("Geef de uitgever:");
            string publisher = Console.ReadLine();

            Newspaper newspaper = new Newspaper(name, publisher, date);
            allReadingRoom.Add(date, newspaper);
        }
        public void AddMagazine()
        {
            Console.WriteLine("Geef de tijdschrift naam:");
            string name = Console.ReadLine();
            Console.WriteLine("Geef in (1-12):");
            byte month;
            while (!byte.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
            {
                Console.WriteLine("Niet geldig, geef een maand tussen 1 en 12:");
            }
            Console.WriteLine("Geef het jaar:");
            uint year;
            while (!uint.TryParse(Console.ReadLine(), out year) || year > 2500)
            {
                Console.WriteLine("Niet geldig geef een geldig jaartal tot 2500:");
            }
            Console.WriteLine("Geef de uitgever:");
            string publisher = Console.ReadLine();

            Magazine magazine = new Magazine(name, publisher, month, year);
            allReadingRoom.Add(DateTime.Now, magazine);
        }
        public void ShowAllMagazines()
        {
            Console.WriteLine("Alle tijdschriften:");
            foreach (var item in allReadingRoom)
            {
                if (item.Value is Magazine)
                {
                    Magazine magazine = (Magazine)item.Value;
                    Console.WriteLine($"Naam: {magazine.Title}, Maand: {magazine.Month}, Jaar: {magazine.Year}, Uitgever: {magazine.Publisher}");
                }
            }
        }
        public void ShowAllNewspapers()
        {
            Console.WriteLine("Alle Kranten:");
            foreach (var item in allReadingRoom)
            {
                if (item.Value is Newspaper)
                {
                    Newspaper newspaper = (Newspaper)item.Value;
                    Console.WriteLine($"Naam: {newspaper.Title}, Datum: {newspaper.Date}, Uitgever: {newspaper.Publisher}");
                }
            }
        }
        public void AcquisitionsReadingRoomToday()
        {
            Console.WriteLine("Aanwinsten in de leeszaal datum:");
            DateTime today = DateTime.Today;
            foreach (var item in allReadingRoom)
            {
                if (item.Key.Date == today)
                {
                    Console.WriteLine($"Titel: {item.Value.Title}, ID: {item.Value.Identification}");
                }
            }
        }
        public class InvalidBookPropertyException : Exception
        {
            public InvalidBookPropertyException(string message, string v) : base(message)
            {
            }
        }

        public class BookNotFoundException : Exception
        {
            public BookNotFoundException(string message) : base(message)
            {
            }
        }
    }
}
