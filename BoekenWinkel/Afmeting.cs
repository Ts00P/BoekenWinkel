using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoekenWinkel
{
    public class Afmeting
    {
        private double hoogte;
        private double breedte;
        private double lengte;

        public Afmeting(double hoogte, double breedte, double lengte)
        {
            this.hoogte = hoogte;
            this.breedte = breedte;
            this.lengte = lengte;
        }

        public double Hoogte { get => hoogte; set => hoogte = value; }
        public double Breedte { get => breedte; set => breedte = value; }
        public double Lengte { get => lengte; set => lengte = value; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
                stringBuilder.Append("Hoogte ")
                .Append(Hoogte)
                .Append(", Breedte ")
                .Append(Breedte)
                .Append(", Lengte ")
                .Append(Lengte);
            return stringBuilder.ToString();
        }
    }
}
