using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoekenWinkel
{
    public class Bestelling
    {
        private DateTime bestelDatum;
        private bool afgehandeld;
        private List<Product> BestellingLijst;


        public Bestelling(DateTime bestelDatum, bool afgehandeld, List<Product> bestellingLijst)
        {
            this.bestelDatum = bestelDatum;
            this.afgehandeld = afgehandeld;
            BestellingLijst = bestellingLijst;
        }

        public DateTime BestelDatum { get => bestelDatum; set => bestelDatum = value; }
        public bool Afgehandeld { get => afgehandeld; set => afgehandeld = value; }
        public List<Product> BestellingLijst1 { get => BestellingLijst; set => BestellingLijst = value; }
    }
}
