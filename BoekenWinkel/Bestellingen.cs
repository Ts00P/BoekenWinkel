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

        public Bestellingen(List<Bestelling> bestelling)
        {
            Bestelling = bestelling;
        }

        public List<Bestelling> Bestelling1 { get => Bestelling; set => Bestelling = value; }
    }
}
