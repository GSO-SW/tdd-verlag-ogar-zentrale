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
        private List<string> unerlaubteZeichen = new List<string> { "", "§", "#", ";", "%", null };

        public Buch(string autor, string titel, long isbn13)
        {

            if (unerlaubteZeichen.Contains(autor))
            {
                throw new ArgumentException();
            }

            if (isbn13.ToString().Length == 13)
            {
                this.isbn13 = isbn13;
            }
            else if (isbn13.ToString().Length == 12)
            {
                int sum = 0;
                string isbn13S = isbn13.ToString();

                for (int i = 1; i <= 12; i++)
                {
                    sum += int.Parse(isbn13S[i - 1].ToString()) * i;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(isbn13));
            }

            this.autor = autor;
            this.titel = titel;
            auflage = 1;
        }

        public Buch(string autor, string titel, int auflage, long isbn13) : this(autor, titel, isbn13)
        {
            if (auflage < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(auflage));
            }

            this.auflage = auflage;
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
        }
    }
}
