namespace Verlag;

public readonly record struct ISBN13
{
    public static ISBN13 Empty => new();

    public bool IsEmpty { get; }

    public long Value { get; }

    public int Checksum { get; }

    public long ISBN10 { get; }
       
    public ISBN13(in long isbn13)
    {
        (Value, Checksum) = GetDigitCount(isbn13) switch
        {
            12 => (isbn13, CalculateChecksum(isbn13)),
            13 => (isbn13 / 10, (int)(isbn13 % 10)),
            _ => throw new ArgumentOutOfRangeException(
                nameof(isbn13), "Die eingegebene ISBN 13 muss 12 oder 13 Ziffern lang sein")
        };

        ISBN10 = RemoveLeadingDigits(Value, 3);
        IsEmpty = false;
    }

    public ISBN13()
    {
        IsEmpty = true;
        Value = 0;
        Checksum = 0;
        ISBN10 = 0;
    }

    private static int GetDigitCount(in long number)
        => number == 0 ? 1 : (int)Math.Floor(Math.Log10(Math.Abs(number)) + 1);

    private static long RemoveLeadingDigits(in long number, in int digits)
        => number % (int)Math.Pow(10, GetDigitCount(number) - digits);

    private static int CalculateChecksum(long isbnWithoutCheckDigit)
    {
        var sum = 0;
        var weight = 1;

        while (isbnWithoutCheckDigit > 0)
        {
            var digit = (int)(isbnWithoutCheckDigit % 10);
            sum += (weight % 2 == 0) ? digit * 3 : digit;
            isbnWithoutCheckDigit /= 10;
            weight++;
        }

        var remainder = sum % 10;
        return remainder == 0 ? 0 : 10 - remainder;
    }
}