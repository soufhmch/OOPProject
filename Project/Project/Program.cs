using Project;
using static Project.Library;

Library library = new Library("Mijn Bibliotheek");

while (true)
{
    Console.WriteLine("\n1. Voeg een boek toe");
    Console.WriteLine("2. Voeg informatie toe aan een boek");
    Console.WriteLine("3. Toon boekinformatie");
    Console.WriteLine("4. Zoek naar een boek");
    Console.WriteLine("5. Verwijder een boek");
    Console.WriteLine("6. Toon alle boeken");
    Console.WriteLine("7. Importeer de boeken uit het csv");
    Console.WriteLine("8. Hoeveel boeken zijn er met dezelfde aantal pagina's");
    Console.WriteLine("9. Voeg een krant toe");
    Console.WriteLine("10. Toon alle kranten");
    Console.WriteLine("11. Voeg een tijdschrift toe");
    Console.WriteLine("12. Toon alle tijdschriften");
    Console.WriteLine("13. Toon de aanwinsten van vandaag in de leeszaal");
    Console.WriteLine("14. Leen een boek uit de bibliotheek");
    Console.WriteLine("15. Breng een geleend boek terug");
    Console.WriteLine("16. Afsluiten");

    Console.Write("\nVoer uw keuze in: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    try
    {
        switch (choice)
        {
            case 1:
                Console.Write("Voer de titel van het boek in: ");
                string title = Console.ReadLine();
                Console.Write("Voer de auteur van het boek in: ");
                string author = Console.ReadLine();
                Book book = new Book(title, author, "", Genre.Fiction, "", 0, DateTime.Now, "");
                library.AddBook(book);
                Console.WriteLine("Boek succesvol toegevoegd.");
                break;
            case 2:
                Console.Write("Voer de titel van het boek in: ");
                title = Console.ReadLine();
                Console.Write("Voer de auteur van het boek in: ");
                author = Console.ReadLine();
                Book bookToModify = library.FindBookByTitleAndAuthor(title, author);
                if (bookToModify != null)
                {
                    Console.Write("Voer ISBN in: ");
                    string isbn = Console.ReadLine();
                    bookToModify.SetISBN(isbn);
                    Console.WriteLine("Boekinformatie succesvol bijgewerkt.");
                }
                else
                {
                    Console.WriteLine("Boek niet gevonden.");
                }
                break;
            case 3:
                Console.Write("Voer de titel van het boek in: ");
                title = Console.ReadLine();
                Console.Write("Voer de auteur van het boek in: ");
                author = Console.ReadLine();
                book = library.FindBookByTitleAndAuthor(title, author);
                if (book != null)
                {
                    book.DisplayBookInfo();
                }
                else
                {
                    Console.WriteLine("Boek niet gevonden.");
                }
                break;
            case 4:
                Console.Write("Voer de titel van het boek in: ");
                title = Console.ReadLine();
                Console.Write("Voer de auteur van het boek in: ");
                author = Console.ReadLine();
                book = library.FindBookByTitleAndAuthor(title, author);
                if (book != null)
                {
                    Console.WriteLine($"Boek gevonden:\nTitel: {book.Title}\nAuteur: {book.Author}");
                }
                else
                {
                    Console.WriteLine("Boek niet gevonden.");
                }
                break;
            case 5:
                Console.Write("Voer de titel van het boek in: ");
                title = Console.ReadLine();
                Console.Write("Voer de auteur van het boek in: ");
                author = Console.ReadLine();
                book = library.FindBookByTitleAndAuthor(title, author);
                if (book != null)
                {
                    library.RemoveBook(book);
                    Console.WriteLine("Boek succesvol verwijderd.");
                }
                else
                {
                    Console.WriteLine("Boek niet gevonden.");
                }
                break;
            case 6:
                foreach (Book b in library.Books)
                {
                    Console.WriteLine($"Titel: {b.Title}, Auteur: {b.Author}");
                }
                break;
            case 7:
                Console.Write("Voer de titel van het boek in: ");
                title = Console.ReadLine();
                Console.Write("Voer de auteur van het boek in: ");
                author = Console.ReadLine();
                book = library.FindBookByTitleAndAuthor(title, author);
                if (book != null && book is ILendable lendable && lendable.IsAvailable)
                {
                    lendable.Borrow();
                    Console.WriteLine($"Je hebt '{title}' geleend. Graag teruggeven voor: {lendable.BorrowingDate.AddDays(lendable.BorrowDays).ToShortDateString()}.");
                }
                else
                {
                    Console.WriteLine("Dit boek is niet beschikbaar om te lenen.");
                }
                break;
            case 8:
                Console.Write("Voer de titel van het boek in: ");
                title = Console.ReadLine();
                Console.Write("Voer de auteur van het boek in: ");
                author = Console.ReadLine();
                book = library.FindBookByTitleAndAuthor(title, author);
                if (book != null && book is ILendable lendable && !lendable.IsAvailable)
                {
                    lendable.Return();
                    Console.WriteLine($"Je hebt '{title}' teruggebracht.");
                }
                else
                {
                    Console.WriteLine("Dit boek was niet geleend of bestaat niet in de bibliotheek.");
                }
                break;
            case 9:
                library.AddNewsPaper();
                break;
            case 10:
                library.ShowAllNewspapers();
                break;
            case 11:
                library.AddMagazine();
                break;
            case 12:
                library.ShowAllMagazines();
                break;
            case 13:
                library.AcquisitionsReadingRoomToday();
                break;

            case 14:
                Console.Write("Voer de titel van het boek in: ");
                title = Console.ReadLine();
                Console.Write("Voer de auteur van het boek in: ");
                author = Console.ReadLine();
                Book bookToBorrow = library.FindBookByTitleAndAuthor(title, author);
                if (bookToBorrow != null && bookToBorrow is ILendable lendable && lendable.IsAvailable)
                {
                    lendable.Borrow();
                    Console.WriteLine(value: $"Je hebt '{title}' geleend. Graag teruggeven voor: {lendable.BorrowingDate.AddDays(lendable.BorrowDays).ToShortDateString()}.");
                }
                else
                {
                    Console.WriteLine("Dit boek is niet beschikbaar om te lenen.");
                }
                break;
            case 15:
                Console.Write("Voer de titel van het boek in: ");
                title = Console.ReadLine();
                Console.Write("Voer de auteur van het boek in: ");
                author = Console.ReadLine();
                Book bookToReturn = library.FindBookByTitleAndAuthor(title, author);
                if (bookToReturn != null && bookToReturn is ILendable lendable && !lendable.IsAvailable)
                {
                    lendable.Return();
                    Console.WriteLine($"Je hebt '{title}' teruggebracht.");
                }
                else
                {
                    Console.WriteLine("Dit boek was niet geleend of bestaat niet in de bibliotheek.");
                }
                break;
        }
    }
    catch (InvalidBookPropertyException ex)
    {
        Console.WriteLine($"Fout bij het toevoegen of wijzigen van boek: {ex.Message}");
    }
    catch (BookNotFoundException ex)
    {
        Console.WriteLine($"Fout: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Er is een onverwachte fout opgetreden: {ex.Message}");
    }
}
