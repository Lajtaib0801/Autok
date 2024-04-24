using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autok
{
    internal class Auto
    {
        public string Tipus { get; private set; }
        public int GyartasEv { get; private set; }
        public int AjtokSzama { get; private set; }
        public string Szin { get; private set; }

        public Auto(string sor)
        {
            string[] adatok = sor.Split(';');
            Tipus = adatok[0];
            GyartasEv = int.Parse(adatok[1]);
            AjtokSzama = int.Parse(adatok[2]);
            Szin = adatok[3];
        }

        public override string ToString()
        {
            return $"{Tipus}";
        }
        
    }
}
