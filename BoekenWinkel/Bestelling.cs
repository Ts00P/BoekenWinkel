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
        private List<Product> bestellingLijst;


        public Bestelling(DateTime bestelDatum, bool afgehandeld, List<Product> bestellingLijst)
        {
            this.bestelDatum = bestelDatum;
            this.afgehandeld = afgehandeld;
            this.bestellingLijst = bestellingLijst;
        }

        public DateTime BestelDatum { get => bestelDatum; set => bestelDatum = value; }
        public bool Afgehandeld { get => afgehandeld; set => afgehandeld = value; }
        public List<Product> BestellingsLijst { get => bestellingLijst; set => bestellingLijst = value; }

        /// <summary>
        ///     Verwijderd een product van de bestellijst.
        /// </summary>
        /// <param name="product"></param>
        public void ProductenVerwijderen(Product product)
        {
            BestellingsLijst.Remove(product);
        }

        /// <summary>
        ///     Een overzicht van de bestelling.
        /// </summary>
        /// <returns></returns>
        public string BestellingAfdrukken()
        {
            var boekenLijst = new List<Boek>();
            var tijdschriftenLijst = new List<Tijdschrift>();

            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Bestelling: ")
                .Append("Datum: ")
                .Append(BestelDatum)
                .AppendLine();

            foreach(var product in BestellingsLijst)
            {
                if (product.GetType().Equals(typeof(Boek)))
                {
                    var boek = (Boek)product;
                    boekenLijst.Add(boek);
                }else if (product.GetType().Equals(typeof(Tijdschrift)))
                {
                    var tijdschrift = (Tijdschrift)product;
                    tijdschriftenLijst.Add(tijdschrift);
                }
                
            }

            stringBuilder.AppendLine("  Boeken: ");

            if (boekenLijst.Count == 0)
            {
                stringBuilder.AppendLine("      Geen boeken gevonden voor deze bestelling.");
            }

            foreach (var boek in boekenLijst)
            {
                stringBuilder.Append("      ");
                stringBuilder.AppendLine(boek.BestelRegel());
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine("  Tijdschriften: ");

            if (tijdschriftenLijst.Count == 0)
            {
                stringBuilder.AppendLine("      Geen Tijdschriften gevonden voor deze bestelling.");
            }

            foreach (var tijdschrift in tijdschriftenLijst)
            {
                stringBuilder.Append("      ");
                stringBuilder.AppendLine(tijdschrift.BestelRegel());
            }

            return stringBuilder.ToString();
        }
    }
}
