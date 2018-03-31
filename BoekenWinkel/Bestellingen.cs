using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoekenWinkel
{
    public class Bestellingen
    {
        private List<Bestelling> bestellingen;

        public Bestellingen(List<Bestelling> bestellingen)
        {
            this.bestellingen = bestellingen;
        }

        public List<Bestelling> BestellingsLijst { get => bestellingen; set => bestellingen = value; }

        /// <summary>
        ///     Voegt een bestelling toe aan de lijst met bestellingen.
        /// </summary>
        /// <param name="bestelling"></param>
        public void VoegBestellingToe(Bestelling bestelling)
        {
            BestellingsLijst.Add(bestelling);
        }

        /// <summary>
        ///     Verwijderd een bestelling uit de lijst van bestellingen.
        /// </summary>
        /// <param name="bestelling"></param>
        public void VerwijderBestelling(Bestelling bestelling)
        {
            BestellingsLijst.Remove(bestelling);
        }

        /// <summary>
        ///     Verwijderd een bestelling uit de lijst van bestellingen.
        /// </summary>
        /// <param name="bestelling"></param>
        public string VerwijderBestelling(DateTime bestelDatum)
        {
            var bestellingen = new List<Bestelling>();

            foreach (var bestelling in BestellingsLijst)
            {
                if (bestelling.BestelDatum.ToString("dd-MM-yyyy").Equals(bestelDatum.ToString("dd-MM-yyyy")))
                {
                    bestellingen.Add(bestelling);
                }
            }

            var stringBuilder = new StringBuilder();

            if (bestellingen.Count == 0)
            {
                stringBuilder.Append("Er Zijn geen bestellingen gevonden op de gegeven datum.");
                return stringBuilder.ToString();
            }

            stringBuilder.Append(ConsoleColor.Red + "De volgende bestellingen zijn verwijderd: ");

            foreach (var bestelling in bestellingen)
            {
                stringBuilder.AppendLine(bestelling.BestellingAfdrukken());
                BestellingsLijst.Remove(bestelling);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Weergeeft een bestelling met een bepaalde datum.
        /// </summary>
        /// <param name="bestelDatum"></param>
        /// <returns></returns>
        public string BestellingAfdrukkenOpDatum(DateTime bestelDatum)
        {
            var bestellingen = new List<string>();
            string bestelRegel = null;

            foreach(var bestelling in BestellingsLijst)
            {
                if (bestelling.BestelDatum.ToString("dd-MM-yyyy").Equals(bestelDatum.ToString("dd-MM-yyyy")))
                {
                    var stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(bestelling.BestellingAfdrukken());
                    bestellingen.Add(stringBuilder.ToString());
                }
            }

            foreach (var bestelling in bestellingen)
            {
                bestelRegel += bestelling;
            }

            if (bestelRegel == null)
            {
                return "Er zijn geen bestelling op deze datum";
            }

            return bestelRegel;
        }

        /// <summary>
        ///     Weergeeft een overzicht van de laatst geplaatste bestelling.
        /// </summary>
        /// <returns></returns>
        public string LaasteBestellingAfdrukken()
        {
            var bestelling = BestellingsLijst.Last();
            return bestelling.BestellingAfdrukken();
        }
    }
}
