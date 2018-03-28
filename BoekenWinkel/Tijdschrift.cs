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
            string iSSN, int aantalTijdschriftenBestellen, DayOfWeek bestelDag, DayOfWeek publicatieDag):base(titel, auteur, afmeting, gewicht, prijs)
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

        public string Bestel()
        {
            return "titel: " + Titel + ", " + "ISSN " + ISSN + ", " + "aantal" + AantalTijdschriftenBestellen;
        }
    }

}
