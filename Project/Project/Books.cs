using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using static System.Reflection.Metadata.BlobBuilder;
using static Project.Library;

public enum Genre
{
    Fiction,
    NonFiction,
    Biography,
    Fantasy,
    Mystery,
    SciFi,
    Schoolbook
}

public class Book : ILendable
{
    public string Title { get; }
    public string Author { get; }
    public string ISBN { get; set; }
    public Genre Genre { get; }
    public string Publisher { get; }
    public int Pages { get; }
    public DateTime PublishedDate { get; }
    public string Language { get; }
    public bool IsAvailable { get; set; }
    public DateTime BorrowingDate { get; set; }
    public int BorrowDays { get; set; }

    public Book(string title, string author, string isbn, Genre genre, string publisher, int pages, DateTime publishedDate, string language)
        : this(title, author, isbn, genre, publisher, pages, publishedDate, language, true)
    {
    }

    private Book(string title, string author, string isbn, Genre genre, string publisher, int pages, DateTime publishedDate, string language, bool isAvailable)
    {
        ValidateBookProperties(title, author, isbn, pages);
        Title = title;
        Author = author;
        ISBN = isbn;
        Genre = genre;
        Publisher = publisher;
        Pages = pages;
        PublishedDate = publishedDate;
        Language = language;
        IsAvailable = isAvailable;
    }

    private static void ValidateBookProperties(string title, string author, string isbn, int pages)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Titel kan nie leeg zijn", nameof(title));
        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Auteur kan niet leeg zijn", nameof(author));
        if (string.IsNullOrWhiteSpace(isbn) || isbn.Length != 13)
            throw new InvalidBookPropertyException("ISBN moet 13 nummers lang zijn", nameof(isbn));
        if (pages <= 0)
            throw new InvalidBookPropertyException("Pagina's moeten een positief getal zijn.", nameof(pages));
    }

    public void Borrow()
    {
        if (IsAvailable)
        {
            BorrowBook();
        }
        else
        {
            Console.WriteLine("Dit boek is niet beschikbaar om te lenen");
        }
    }

    private void BorrowBook()
    {
        IsAvailable = false;
        BorrowingDate = DateTime.Now;
        SetBorrowDays();
        Console.WriteLine($"Boek is geleend gelieve terug te brengen voor: {BorrowingDate.AddDays(BorrowDays).ToShortDateString()}");
    }

    private void SetBorrowDays()
    {
        BorrowDays = Genre == Genre.Schoolbook ? 10 : 20;
    }

    public void Return()
    {
        if (!IsAvailable)
        {
            ReturnBook();
        }
        else
        {
            Console.WriteLine("Dit boek is niet gemarkeerd als geleend");
        }
    }

    private void ReturnBook()
    {
        IsAvailable = true;
        var returnDate = DateTime.Now;
        var dueDate = BorrowingDate.AddDays(BorrowDays);
        DisplayReturnStatus(returnDate, dueDate);
    }

    private void DisplayReturnStatus(DateTime returnDate, DateTime dueDate)
    {
        if (returnDate > dueDate)
        {
            Console.WriteLine("Boek is te laat terug gebracht");
        }
        else
        {
            Console.WriteLine("Boek is op tijd terug gebracht");
        }
    }

    internal void DisplayBookInfo()
    {
        throw new NotImplementedException();
    }

    internal void SetISBN(string? isbn)
    {
        throw new NotImplementedException();
    }
}

public interface ILendable
{
    bool IsAvailable { get; }

    void Borrow();
    void Return();
}