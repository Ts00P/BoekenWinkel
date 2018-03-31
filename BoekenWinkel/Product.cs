using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoekenWinkel
{
    public abstract class Product
    {
        private string titel;
        private string auteur;
        private Afmeting afmeting;
        private int gewicht;
        private decimal prijs;
        private int voorraad;

        protected Product(string titel, string auteur, Afmeting afmeting, int gewicht, decimal prijs, int voorraad)
        {
            Titel = titel;
            Auteur = auteur;
            Afmeting = afmeting;
            Gewicht = gewicht;
            Prijs = prijs;
            Voorraad = voorraad;
        }

        public string Titel { get => titel; set => titel = value; }
        public string Auteur { get => auteur; set => auteur = value; }
        public Afmeting Afmeting { get => afmeting; set => afmeting = value; }
        public int Gewicht { get => gewicht; set => gewicht = value; }
        public decimal Prijs { get => prijs; set => prijs = value; }
        public int Voorraad { get => voorraad; set => voorraad = value; }
    }
}
