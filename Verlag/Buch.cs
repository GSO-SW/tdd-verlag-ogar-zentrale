using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlag
{
    public class Buch
    {
        private string autor;
        private string titel;
        private int auflage;
        private long isbn13;
        private string isbn;
        string isbn10;
        private List<string> unerlaubteZeichen = new List<string> { "", "§", "#", ";", "%", null };


        public Buch(string autor, string titel)
        {

            if (unerlaubteZeichen.Contains(autor))
            {
                throw new ArgumentException();
            }

            this.autor = autor;
            this.titel = titel;
            auflage = 1;
        }

        public Buch(string autor, string titel, int auflage) : this(autor, titel)
        {
            if (auflage < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(auflage));
            }

            this.auflage = auflage;
        }

        public Buch(string autor, string titel, int auflage, long isbn13) : this(autor, titel, auflage)
        {
            ISBN13_Berechnen(isbn13);
        }

        public Buch(string autor, string titel, int auflage, string isbn) : this(autor, titel, auflage)
        {
            this.isbn = isbn;
        }


        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public string Titel { get { return titel; } }

        public int Auflage
        {
            get { return auflage; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                auflage = value;
            }
        }

        public long ISBN13
        {
            get { return isbn13; }
            set { ISBN13_Berechnen(value); }
        }

        public string ISBN10
        {
            get { return isbn10; }
        }

        public string ISBN
        {
            set
            {
                isbn = value;
                ISBN13_Berechnen(long.Parse(isbn.Replace("-", "")));
            }
        }

        private void ISBN13_Berechnen(long isbn13)
        {
            if (isbn13.ToString().Length < 12 || isbn13.ToString().Length > 13)
            {
                //Die ISBN darf nicht zu kurz, oder zu lang sein.
                throw new ArgumentOutOfRangeException(nameof (isbn13));
            }
            else if (isbn13.ToString().Length == 12)
            {
                //Pruefsumme Wird Berechnet
                this.isbn13 = long.Parse(isbn13.ToString() + ISBN13_PruefZiffer(isbn13));
            }
            else
            {
                if (ISBN13_PruefZiffer(long.Parse(isbn13.ToString().Substring(0,12))) == long.Parse(isbn13.ToString().Substring(12,1)))
                {
                    this.isbn13 = isbn13;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(isbn13));
                }
            }


            string isbn10 = isbn13.ToString().Substring(3, 9);

            this.isbn10 = isbn10 + ISBN10_PruefZiffer(isbn10);
        }

        private int ISBN13_PruefZiffer(long isbn13)
        {
            if (isbn13.ToString().Length == 12)
            {
                int sum = 0;

                for (int i = 0; i < 12; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += int.Parse(isbn13.ToString().Substring(i, 1));
                    }
                    else
                    {
                        sum += 3 * int.Parse(isbn13.ToString().Substring(i, 1));
                    }
                }

                sum = (int)(Math.Ceiling((double)sum / 10) * 10) - sum;

                return sum;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(isbn13));
            }
        }

        private string ISBN10_PruefZiffer(string isbn)
        {
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (10 - i) * Int32.Parse(isbn[i].ToString());
            float div = sum / 11;
            float rem = sum % 11;
            if (rem == 0)
                return "0";
            else if (rem == 1)
                return "X";
            else
                return (11 - rem).ToString();
        }
    }
}
