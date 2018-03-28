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

        protected Boek(string druk, string iSBN, int minVoorraad, int maxVoorraad, string titel, string auteur, Afmeting afmeting, int gewicht, decimal prijs) : base(titel, auteur, afmeting, gewicht, prijs)
        {
            this.druk = druk;
            ISBN = iSBN;
            this.minVoorraad = minVoorraad;
            this.maxVoorraad = maxVoorraad;
        }

        public string Druk { get => druk; set => druk = value; }
        public string ISBN1 { get => ISBN; set => ISBN = value; }
        public int MinVoorraad { get => minVoorraad; set => minVoorraad = value; }
        public int MaxVoorraad { get => maxVoorraad; set => maxVoorraad = value; }
    }
}
