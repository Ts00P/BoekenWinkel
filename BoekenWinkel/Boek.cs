using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoekenWinkel
{
    public class Boek : Product
    {
        private string druk;
        private string ISBN;
        private int minVoorraad;
        private int maxVoorraad;

        public Boek(string druk, string ISBN, int minVoorraad, int maxVoorraad, string titel, string auteur, Afmeting afmeting, int gewicht, decimal prijs, int voorraad) 
            : base(titel, auteur, afmeting, gewicht, prijs, voorraad)
        {
            this.druk = druk;
            this.ISBN = ISBN;
            this.minVoorraad = minVoorraad;
            this.maxVoorraad = maxVoorraad;
        }

        public string Druk { get => druk; set => druk = value; }
        public string ISBN1 { get => ISBN; set => ISBN = value; }
        public int MinVoorraad { get => minVoorraad; set => minVoorraad = value; }
        public int MaxVoorraad { get => maxVoorraad; set => maxVoorraad = value; }

        public string Afdrukken()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Boek: ")
                .Append(Titel)
                .AppendLine()
                .Append("   Auteur: ")
                .Append(Auteur)
                .Append(", Prijs: ")
                .Append(Prijs)
                .Append(", Druk: ")
                .Append(Druk)
                .Append(", ISBN: ")
                .Append(ISBN1)
                .AppendLine()
                .Append("   ")
                .Append(Afmeting.ToString())
                .Append(", Gewicht: ")
                .Append(Gewicht)
                .AppendLine()
                .Append("   Voorraad: ")
                .Append(Voorraad)
                .Append(", MinVoorraad: ")
                .Append(MinVoorraad)
                .Append(", MaxVoorraad: ")
                .Append(MaxVoorraad);
            return stringBuilder.ToString();
        }

        public string BestelRegel()
        {
            var stringBuilder = new StringBuilder();
                stringBuilder.Append("   Titel: ")
                .Append(Titel)
                .Append(", Auteur: ")
                .Append(Auteur)
                .Append(", ISBN: ")
                .Append(ISBN1)
                .Append(", Aantal: ")
                .Append(MaxVoorraad - Voorraad);
            return stringBuilder.ToString();
        }
    }
}
