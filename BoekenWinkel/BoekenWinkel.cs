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

        public BoekenWinkel(string contactInformatie, string openingsTijden, List<Product> voorraad, Bestellingen bestellingen)
        {
            this.contactInformatie = contactInformatie;
            this.openingsTijden = openingsTijden;
            this.voorraad = voorraad;
            this.bestellingen = bestellingen;
        }

        public string ContactInformatie { get => contactInformatie; set => contactInformatie = value; }
        public string OpeningsTijden { get => openingsTijden; set => openingsTijden = value; }
        public List<Product> Voorraad { get => voorraad; set => voorraad = value; }
        public Bestellingen Bestellingen { get => bestellingen; set => bestellingen = value; }


        public Product ZoekProduct(string id)
        {
            foreach (var product in Voorraad)
            {
                if (IsTijdschrift(product))
                {
                    var tijdschrift = (Tijdschrift)product;
                    if (id.Equals(tijdschrift.ISSN1))
                    {
                        return (Product)tijdschrift;
                    }
                }

                if (IsBoek(product))
                {
                    var boek = (Boek)product;
                    if (id.Equals(boek.ISBN1))
                    {
                        return (Product)boek;
                    }
                }
            }
            return null;
        }

        public void VerkoopProduct(string id, int verkocht)
        {
            var product = ZoekProduct(id);
            product.Voorraad = product.Voorraad - verkocht;
        }

        public int VoorraadProduct(string id)
        {
            var product = ZoekProduct(id);

            return product.Voorraad;
        }

        public void VerwijderProduct(string id)
        {
            var product = ZoekProduct(id);

            Voorraad.Remove(product);
        }

        public void BestelBoek()
        {

        }

        public List<string> GenereerBestellijst()
        {
            var genereerLijst = new List<string>();
            var producten = new List<Product>();

            genereerLijst.Add(DateTime.Now + "BestelLijst: ");

            foreach (var product in Voorraad)
            {
                producten.Add(product);
                genereerLijst.Add(genereerProductLijst(product));
            }

            var bestelling = new Bestelling(DateTime.Now, false, producten);

            bestellingen.Bestelling1.Add(bestelling);
            return genereerLijst;
        }

        public void BestellingAfhandelen()
        {   
            foreach(var bestelling in Bestellingen.Bestelling1)
            {
                if (!bestelling.Afgehandeld)
                {
                    foreach(var product in bestelling.BestellingLijst1)
                    {
                        VoorraadAanpassen(product);
                    }
                }
            }
        }

        public string genereerProductLijst(Product product)
        {
            if (IsTijdschrift(product))
            {
                var tijdschrift = (Tijdschrift)product;
                var day = DateTime.Now.DayOfWeek;

                if (tijdschrift.BestelDag1 == day)
                {
                    var aantal = tijdschrift.AantalTijdschriftenBestellen1;
                    var stringbuilder = new StringBuilder();
                    stringbuilder.Append("ISSN ").
                        Append(tijdschrift.ISSN1).
                        Append(", titel ").
                        Append(tijdschrift.Titel).
                        Append(", aantal ").
                        Append(aantal);
                    return stringbuilder.ToString();
                }
            }

            if (IsBoek(product))
            {
                var boek = (Boek)product;
                if (boek.Voorraad <= boek.MinVoorraad)
                {
                    var aantal = boek.MaxVoorraad - boek.Voorraad;

                    var stringbuilder = new StringBuilder();
                    stringbuilder.Append("ISBN ").
                        Append(boek.ISBN1).
                        Append(", titel ").
                        Append(boek.Titel).
                        Append(", aantal ").
                        Append(aantal);
                    return stringbuilder.ToString();
                }
            }
            return null;
        }

        public List<string> BestellingInzien(DateTime date)
        {
            var bestelling = new List<string>();

            bestelling.Add("Bestelling: " + DateTime.Now.ToString("dd-MM-yyyy"));

            foreach(var bestel in Bestellingen.Bestelling1)
            {
                var bestelDatum = bestel.BestelDatum.ToString("dd-MM-yyyy");
                var zoekDate = date.ToString("dd-MM-yyyy");

                if (bestelDatum.Equals(zoekDate))
                {
                    foreach (var product in bestel.BestellingLijst1)
                    {
                        bestelling.Add(genereerProductLijst(product));
                    }
                }
            }
            return bestelling;
        }

        public List<Bestelling> nietAfgewerkteBestellingen()
        {
            var bestellingLijst = new List<Bestelling>();

            foreach (var bestelling in Bestellingen.Bestelling1)
            {
                if (!bestelling.Afgehandeld)
                {
                    bestellingLijst.Add(bestelling);
                }
            }
            return bestellingLijst;
        }
        
        public void BoekVoorraadAanpassen(Boek boek, int min, int max)
        {
            boek.MinVoorraad = min;
            boek.MaxVoorraad = max;
        }

        public void TijdschriftBestelAantalAanpassen(Tijdschrift tijdschrift, int aantal)
        {
            tijdschrift.AantalTijdschriftenBestellen1 = aantal;
        }

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

        private bool IsBoek(Product product)
        {
            if (product.GetType() == typeof(Boek))
            {
                return true;
            }
            return false;
        }

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
