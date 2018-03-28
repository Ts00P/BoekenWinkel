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

        public List<string> GenereerBestellijst()
        {
            foreach (var product in Voorraad)
            {
                if (IsBoek(product)){
                    var boek = (Boek)product;
                    if (boek.Voorraad <= boek.MinVoorraad)
                    {
                        var aantal = boek.MaxVoorraad - boek.Voorraad;
                        //Bestel boek
                    }
                }

                if (IsTijdschrift(product))
                {
                    var tijdschrift = (Tijdschrift)product;
                    var day = DateTime.Now.DayOfWeek;

                    if (tijdschrift.BestelDag1 == day)
                    {
                        //Bestel
                    }
                }
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
