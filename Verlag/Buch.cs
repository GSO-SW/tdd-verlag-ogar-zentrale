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
            ISBN13_Ueberpruefen(isbn13);
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
            set { ISBN13_Ueberpruefen(value); }
        }
        

        private void ISBN13_Ueberpruefen(long isbn13)
        {
            if (isbn13.ToString().Length < 12 || isbn13.ToString().Length > 13)
            {
                //Die ISBN darf nicht zu kurz, oder zu lang sein.
                throw new ArgumentOutOfRangeException(nameof (isbn13));
            }
            else if (isbn13.ToString().Length == 12)
            {
                //Pruefsumme Wird Berechnet
            }
            else
            {
                this.isbn13 = isbn13;
            }
        }
    }
}
