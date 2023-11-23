namespace Verlag;

public record Buch
{
    private string autor = null!;
    private int auflage;

    public string Autor
    {
        get => autor;
        set
        {
            if (string.IsNullOrWhiteSpace(value)
                || value.Any(x => x is '#' or ';' or '§' or '%'))
                throw new ArgumentException("Der Autor darf keine verbotenen Zeichen beinhalten", nameof(value));

            autor = value;
        }
    }

    public string Titel { get; }

    public int Auflage
    {
        get => auflage;
        set
        {
            if (value < 1)
                throw new ArgumentOutOfRangeException(nameof(value), "Die Auflage muss mindestens 1 sein");

            auflage = value;
        }
    }

    public ISBN13 ISBN13 { get; }

    public Buch(string autor, string titel, ISBN13 isbn13, int auflage = 1)
    {
        Autor = autor;
        Titel = titel;
        ISBN13 = isbn13;
        Auflage = auflage;
    }

    public Buch(string autor, string titel, int auflage = 1) : this(autor, titel, ISBN13.Empty, auflage) { }
}