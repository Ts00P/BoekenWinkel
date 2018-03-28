using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoekenWinkel
{
    public class Bestellingen
    {
        private List<Bestelling> Bestelling;

        private BoekenWinkel BoekenWinkel;

        public Bestellingen(List<Bestelling> bestelling, BoekenWinkel boekenWinkel)
        {
            Bestelling = bestelling;
        }

        public List<Bestelling> Bestelling1 { get => Bestelling; set => Bestelling = value; }

        public List<string> LaasteBestellingAddrukken()
        {
            var BestelLijst = new List<string>();
            var index = Bestelling.Count - 1;

            foreach (var product in Bestelling[index].BestellingLijst1)
            {
                BestelLijst.Add(BoekenWinkel.genereerProductLijst(product));
            }

            return BestelLijst;
        }
    }
}
