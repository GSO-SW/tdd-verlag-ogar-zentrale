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

        public Buch(string autor, string titel)
        {
            if (autor is null or "" || autor.Any(c => "#;§%".Contains(c)))
            { throw new ArgumentException("Autorname ungültig", nameof(autor)); }
            else this.autor = autor;

            this.titel = titel;

            auflage = 1;
        }
        public Buch(string autor, string titel, int auflage) :this (autor, titel)
        {
            if (auflage > 0)
            { this.auflage = auflage; }
            else { throw new ArgumentOutOfRangeException("auflage zu klein", nameof(auflage)); }
        }
        public Buch(string autor, string titel, int auflage, string ISBN) :this(autor, titel, auflage)
        {
            this.ISBN = ISBN;

        }   



        public string Autor { get { return autor; } set { autor = value; } }
        public string Titel { get { return titel; } }
        public int Auflage { get { return auflage; } 
            set {
                if (value > 0)
                { auflage = value; }
                else { throw new ArgumentOutOfRangeException("auflage zu klein", nameof(auflage)); }
            }
        }
        public string ISBN { get { return iSBN; }
            set {
                if (value.Length == 17 && value.Count(c => c == '-') == 4)
                { this.iSBN = new string(value.Where(c => c != '-').ToArray()); }

                else if (value.Length == 13)
                { this.iSBN = value; }

                else if (value.Length == 12)
                {
                    if (value.Contains("-"))
                    { value = new string(value.Where(c => c != '-').ToArray()); }
                    int pruefsumme = 0;
                    for (int i = 0; i < value.Length; i += 2)
                    {
                        pruefsumme += Convert.ToInt32(value[i]) + Convert.ToInt32(value[i + 1] * 3);
                    }
                    value += ((pruefsumme % 11 - 10) * -1).ToString();
                    this.iSBN = value;
                }
                else { throw new ArgumentOutOfRangeException("Prüfsummenfehler", nameof(value)); }
            }   
        }

    }