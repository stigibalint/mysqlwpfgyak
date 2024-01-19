using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldtimerGUI
{
    internal class Auto
    {
        public Auto(string rendszam, string szin, string nev, int evjarat, int ar)
        {
            Rendszam = rendszam;
            Szin = szin;
            Nev = nev;
            Evjarat = evjarat;
            Ar = ar;
        }

        public string Rendszam {  get; set; }
        public string Szin {  get; set; }
        public string Nev {  get; set; }
        public int Evjarat {  get; set; }
        public int Ar {  get; set; }

    }
}
