using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoekenWinkel
{
    public class BoekenWinkel
    {
        private string contactInformatie;
        private string openingsTijden;
        private List<Product> voorraad;
        private Bestellingen bestellingen;

        public BoekenWinkel()
        {
            bestellingen = new Bestellingen(new List<Bestelling>());
            voorraad = new List<Product>();
        }

        public string ContactInformatie { get => contactInformatie; set => contactInformatie = value; }
        public string OpeningsTijden { get => openingsTijden; set => openingsTijden = value; }
        public List<Product> Voorraad { get => voorraad; set => voorraad = value; }
        public Bestellingen Bestellingen { get => bestellingen; set => bestellingen = value; }


        /// <summary>
        ///     Zoekt een product uit de voorraad.
        /// </summary>
        /// <param name="id">ISSN/ISBN nummer.</param>
        /// <returns></returns>
        public Product ZoekProduct(string id)
        {
            foreach (var product in Voorraad)
            {
                if (IsTijdschrift(product))
                {
                    var tijdschrift = (Tijdschrift)product;
                    if (id.Equals(tijdschrift.ISSN1))
                    {
                        return tijdschrift;
                    }
                }

                if (IsBoek(product))
                {
                    var boek = (Boek)product;
                    if (id.Equals(boek.ISBN1))
                    {
                        return boek;
                    }
                }
            }
            return null;
        }

        /// <summary>
        ///     Berekent de nieuwe voorraad met het aantal verkochte tijdschriften.
        /// </summary>
        /// <param name="ISSN">Het ISSN nummer.</param>
        /// <param name="aantalVerkocht">Aantal tijdschriften die zijn verkocht.</param>
        /// <returns></returns>
        public string VerkoopTijdschrift(string ISSN, int aantalVerkocht)
        {
            var tijdschrift = (Tijdschrift)ZoekProduct(ISSN);

            if (tijdschrift == null)
            {
                return "Er bestaat geen product voor het opgegeven nummer.";
            }

            tijdschrift.Voorraad -= aantalVerkocht;
            return VerkoopRegel(tijdschrift, aantalVerkocht);
        }

        /// <summary>
        ///     Berekent de nieuwe voorraad met het aantal verkochte boeken.
        /// </summary>
        /// <param name="ISBN">Het ISBN nummer.</param>
        /// <param name="aantalVerkocht">Aantal boeken die zijn verkocht.</param>
        /// <returns></returns>
        public string VerkoopBoek(string ISBN, int aantalVerkocht)
        {
            var boek = (Boek)ZoekProduct(ISBN);

            if (boek == null)
            {
                return "Er bestaat geen product voor het opgegeven nummer.";
            }

            boek.Voorraad-= aantalVerkocht;

            return VerkoopRegel(boek, aantalVerkocht);
        }

        /// <summary>
        ///     Berekent de nieuwe voorraad met het aantal verkochte boeken.
        /// </summary>
        /// <param name="ISBN">Het ISBN nummer.</param>
        /// <param name="aantalVerkocht">Aantal boeken die zijn verkocht.</param>
        public string VerkoopBoek(string titel, string auteur, int aantalVerkocht)
        {
            foreach(var product in Voorraad)
            {
                if (IsBoek(product) && product.Titel == titel && product.Auteur == auteur)
                {
                    product.Voorraad -= aantalVerkocht;
                    return VerkoopRegel(product, aantalVerkocht);
                }
            }

            return "Er is geen boek gevonden met de opgegeven titel en auteur";
        }

        /// <summary>
        ///     Maakt een verkoopregel aan.
        /// </summary>
        /// <param name="product">product dat is verkocht.</param>
        /// <param name="aantalVerkocht">Aantal verkochte producten.</param>
        /// <returns>De verkoopregel</returns>
        public string VerkoopRegel(Product product, int aantalVerkocht)
        {

            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Titel: ")
                .Append(product.Titel)
                .Append(", Aantal: ")
                .Append(aantalVerkocht)
                .Append(", Prijs per stuk: ")
                .Append(product.Prijs)
                .Append(", Totaal = ")
                .Append(product.Prijs * aantalVerkocht);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Toont alle boeken die op voorraad zijn.
        /// </summary>
        /// <returns>De elementen van alle boeken die op voorraad zijn.</returns>
        public string ToonBoekVoorraad()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Voorradige Boeken: ");
            foreach(var product in Voorraad)
            {
                if (IsBoek(product))
                {
                    var boek = (Boek)product;
                    if (boek.Voorraad >= boek.MinVoorraad){
                        stringBuilder.AppendLine(boek.Afdrukken());
                    }
                }
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Toont alle tijdschriften die op voorraad zijn.
        /// </summary>
        /// <returns>De elementen van alle tijdschriften die op vooraad zijn</returns>
        public string ToonTijdschriftVoorraad()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Voorradige Tijdschriften: ")
                .AppendLine();

            foreach (var product in Voorraad)
            {
                if (IsTijdschrift(product))
                {
                    var tijdschrift = (Tijdschrift)product;

                    if (tijdschrift.Voorraad > 0)
                    {
                        stringBuilder.AppendLine(tijdschrift.Afdrukken());
                    }
                }
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Verwijderd een product uit de voorraad.
        /// </summary>
        /// <param name="id"></param>
        public void VerwijderProduct(string id)
        {
            var product = ZoekProduct(id);

            Voorraad.Remove(product);
        }

        /// <summary>
        ///     Maakt een nieuwe instantie van een boek en voegt die toe aan de voorraad.
        /// </summary>
        /// <param name="ISBN"></param>
        /// <param name="druk"></param>
        /// <param name="titel"></param>
        /// <param name="auteur"></param>
        /// <param name="gewicht"></param>
        /// <param name="prijs"></param>
        /// <param name="voorraad"></param>
        /// <param name="maxVoorraad"></param>
        /// <param name="minVoorraad"></param>
        /// <param name="hoogte"></param>
        /// <param name="breedte"></param>
        /// <param name="lengte"></param>
        public void NieuwBoek(string ISBN, string druk, string titel, string auteur,
            int gewicht, decimal prijs, int voorraad, int maxVoorraad, int minVoorraad, double hoogte, double breedte, double lengte)
        {
            var afmeting = new Afmeting(hoogte, breedte, lengte);

            var boek = new Boek(druk, ISBN, minVoorraad, maxVoorraad, titel, auteur, afmeting, gewicht, prijs, voorraad);
            Voorraad.Add(boek);
        }

        /// <summary>
        ///     Maakt een nieuwe instantie van een tijdschrift en voegt die toe aan de voorraad.
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="auteur"></param>
        /// <param name="hoogte"></param>
        /// <param name="breedte"></param>
        /// <param name="lengte"></param>
        /// <param name="gewicht"></param>
        /// <param name="prijs"></param>
        /// <param name="iSSN"></param>
        /// <param name="aantalTijdschriftenBestellen"></param>
        /// <param name="bestelDag"></param>
        /// <param name="publicatieDag"></param>
        /// <param name="voorraad"></param>
        public void NieuwTijdschrift(string titel, string auteur, double hoogte, double breedte, double lengte, int gewicht, decimal prijs,
            string iSSN, int aantalTijdschriftenBestellen, DayOfWeek bestelDag, DayOfWeek publicatieDag, int voorraad)
        {
            var afmeting = new Afmeting(hoogte, breedte, lengte);

            var tijdschrift = new Tijdschrift(titel, auteur, afmeting, gewicht, prijs, iSSN, aantalTijdschriftenBestellen, bestelDag, publicatieDag, voorraad);
            Voorraad.Add(tijdschrift);
        }

        /// <summary>
        ///     Geeft een overzicht van alle niet verwerkte bestellingen.
        /// </summary>
        /// <returns></returns>
        public string NietVerwerkteBestellingen()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Open bestellingen: ");

            foreach (var bestelling in Bestellingen.BestellingsLijst)
            {
                if (!bestelling.Afgehandeld)
                {
                    stringBuilder.AppendLine(bestelling.BestellingAfdrukken());
                }
            }
            return stringBuilder.ToString();
        }
        
        /// <summary>
        ///     Past de minimale en maximale voorraad van een boek aan.
        /// </summary>
        /// <param name="boek"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void BoekVoorraadAanpassen(Boek boek, int min, int max)
        {
            boek.MinVoorraad = min;
            boek.MaxVoorraad = max;
        }

        /// <summary>
        ///     Past het bestelaantal aan van een tijdschrift.
        /// </summary>
        /// <param name="tijdschrift"></param>
        /// <param name="aantal"></param>
        public void TijdschriftBestelAantalAanpassen(Tijdschrift tijdschrift, int aantal)
        {
            tijdschrift.AantalTijdschriftenBestellen1 = aantal;
        }

        /// <summary>
        ///     Doorloopt de hele voorraad en besteld producten die onder de minimale voorraad zitten, of waarvan het de besteldag is.
        /// </summary>
        /// <returns>Een overzicht met de bestelde boeken / tijdschriften.</returns>
        public string GenereerBestelLijst()
        {
            var producten = new List<Product>();

            foreach(var product in Voorraad)
            {
                if (IsBoek(product))
                {
                    var boek = (Boek)product;
                    
                    if (boek.Voorraad < boek.MinVoorraad)
                    {
                        producten.Add(boek);
                    }

                }else if (IsTijdschrift(product))
                {
                    var tijdschrift = (Tijdschrift)product;

                    if (tijdschrift.BestelDag1.Equals(DateTime.Now.DayOfWeek))
                    {
                        producten.Add(tijdschrift);
                    }
                }
            }

            var bestelling = new Bestelling(DateTime.Now, false, producten);

            Bestellingen.BestellingsLijst.Add(bestelling);
            return bestelling.BestellingAfdrukken();
        }

        /// <summary>
        ///     Past de voorraad van tijdschriften / boeken aan naar het maximale.
        /// </summary>
        /// <param name="product"></param>
        public void VoorraadAanpassen(Product product)
        {
            if (IsBoek(product)){
                var boek = (Boek)product;
                product.Voorraad = boek.MaxVoorraad - boek.Voorraad;

            }else if (IsTijdschrift(product))
            {
                var tijdschrift = (Tijdschrift)product;
                product.Voorraad = tijdschrift.AantalTijdschriftenBestellen1;
            }
        }

        /// <summary>
        ///     Controle of een product een boek is.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private bool IsBoek(Product product)
        {
            if (product.GetType() == typeof(Boek))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Controle of een product een tijdschrift is.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private bool IsTijdschrift(Product product)
        {
            if (product.GetType() == typeof(Tijdschrift))
            {
                return true;
            }
            return false;
        }
    }
}
