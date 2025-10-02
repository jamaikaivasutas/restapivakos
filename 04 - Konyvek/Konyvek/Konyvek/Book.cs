﻿public class Book
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime Birthday { get; set; }

    public string Title { get; set; }

    public string ISBN { get; set; }

    public string Publisher { get; set; }

    public int PublishYear { get; set; }

    public int Price { get; set; }

    public string Theme { get; set; }

    public int PageNumber { get; set; }

    public int Honorarium { get; set; }

    public string ToFullString()
    {
        return $"{FirstName}\t{LastName}\t{Birthday}\t{Title}\t{ISBN}\t{Publisher}\t{PublishYear}\t{Price}\t{Theme}\t{PageNumber}\t{Honorarium}";
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}  ({Birthday:yyyy-mm-dd}) - {Title}({PublishYear})";
    }
}
