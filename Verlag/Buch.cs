using System;
using Verlag;

namespace Verlag
{
    public class Buch
    {
        private string autor;
        private string titel;
        private int auflage;

        public Buch(string autor, string titel, int auflage)
        {
            this.autor = autor;
            this.titel = titel;
            if (auflage > 0)
                this.auflage = auflage;
            else throw new ArgumentOutOfRangeException("auflage zu klein", nameof (auflage));
        }
        public Buch(string autor, string titel)
        {
            this.autor = autor;
            this.titel = titel;
            auflage = 1;
        }

        public string Autor { get { return autor; } set { autor = value; } }
        public string Titel { get { return titel; } }
        public int Auflage { get { return auflage; } 
            set { 
                if (auflage > 0)
                auflage = value; 
                else throw new ArgumentOutOfRangeException("auflage zu klein", nameof (auflage));
            }
        }


    }
}
