using System;
using Verlag;

namespace Verlag
{
    public class Buch
    {
        private string autor;
        private string titel;
        private int auflage;
        private string iSBN;
        private long iSBN13;

        public Buch(string autor, string titel)
        {
            if (autor is null or "" || autor.Any(c => "#;§%".Contains(c)))  
                throw new ArgumentException("Autorname ungültig", nameof(autor));
            else this.autor = autor;

            this.titel = titel;

            auflage = 1;
        }
        public Buch(string autor, string titel, int auflage) :this (autor, titel)
        {
            if (auflage > 0)
                this.auflage = auflage;
            else throw new ArgumentOutOfRangeException("auflage zu klein", nameof(auflage));
        }
        public Buch(string autor, string titel, int auflage, string ISBN) :this(autor, titel, auflage)
        {
            this.iSBN = ISBN;
        }
        public Buch(string autor, string titel, int auflage, long ISBN13) :this(autor, titel, auflage)
        {
            if (Convert.ToString(ISBN13).Length == 13)
                this.iSBN13 = ISBN13;
            else
            {
                int summe = 0;
                for (int i = 1; i < 13; i += 2)
                {
                    summe += 3 * Convert.ToInt32(Convert.ToString(ISBN13)[i]);
                }
            }
        }



        public string Autor { get { return autor; } set { autor = value; } }
        public string Titel { get { return titel; } }
        public int Auflage { get { return auflage; } 
            set { 
                if (value > 0)
                auflage = value; 
                else throw new ArgumentOutOfRangeException("auflage zu klein", nameof (auflage));
            }
        }
        public string ISBN { get { return iSBN; } set { iSBN = value; } }
        public long ISBN13 { get { return iSBN13; } set { iSBN13 = value; } }

    }
}
