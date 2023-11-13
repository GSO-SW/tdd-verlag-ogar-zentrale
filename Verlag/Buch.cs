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
    }
}
