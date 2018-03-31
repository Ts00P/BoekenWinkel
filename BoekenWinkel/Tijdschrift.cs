using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoekenWinkel
{
    public class Tijdschrift : Product
    {
        private string ISSN;
        private int AantalTijdschriftenBestellen;
        private DayOfWeek BestelDag;
        private DayOfWeek PublicatieDag;

        public Tijdschrift(string titel, string auteur, Afmeting afmeting, int gewicht, decimal prijs,
            string iSSN, int aantalTijdschriftenBestellen, DayOfWeek bestelDag, DayOfWeek publicatieDag, int voorraad)
            : base(titel, auteur, afmeting, gewicht, prijs, voorraad)
        {
            ISSN = iSSN;
            AantalTijdschriftenBestellen = aantalTijdschriftenBestellen;
            BestelDag = bestelDag;
            PublicatieDag = publicatieDag;
        }

        public string ISSN1 { get => ISSN; set => ISSN = value; }
        public int AantalTijdschriftenBestellen1 { get => AantalTijdschriftenBestellen; set => AantalTijdschriftenBestellen = value; }
        public DayOfWeek BestelDag1 { get => BestelDag; set => BestelDag = value; }
        public DayOfWeek PublicatieDag1 { get => PublicatieDag; set => PublicatieDag = value; }

        /// <summary>
        ///     Overzicht met alle elementen van een tijdschrift.
        /// </summary>
        /// <returns></returns>
        public string Afdrukken()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Tijdschrift: ")
                .Append(Titel)
                .AppendLine()
                .Append("   Auteur: ")
                .Append(Auteur)
                .Append(", Prijs: ")
                .Append(Prijs)
                .Append(", ISSN: ")
                .Append(ISSN1)
                .Append("   Voorraad: ")
                .Append(Voorraad)
                .AppendLine()
                .Append("   ")
                .Append(Afmeting.ToString())
                .Append(", Gewicht: ")
                .Append(Gewicht);
            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Bestelregel voor een te bestellen tijdschrift.
        /// </summary>
        /// <returns></returns>
        public string BestelRegel()
        {
            var stringBuilder = new StringBuilder();
                 stringBuilder.Append("   Titel: ")
                .Append(Titel)
                .Append(", Auteur: ")
                .Append(Auteur)
                .Append(", ISSN: ")
                .Append(ISSN1)
                .Append(", Aantal: ")
                .Append(AantalTijdschriftenBestellen1 - Voorraad);
            return stringBuilder.ToString();
        }
    }
}
