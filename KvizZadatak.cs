using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeomProj
{
    public class KvizZadatak : Zadatak
    {
        public string[] netacniOdgovori {  get; set; }
        public KvizZadatak(string pitanje, TimeSpan vreme, string odgovor, string[] netacniOdgovori) : base(pitanje, vreme, odgovor)
        {
            this.netacniOdgovori = netacniOdgovori;
        }
        public (int, string[]) PromesajOdgovore()
        {
            string[] odgovori = new string[4];
            odgovori[0] = Odgovor;
            odgovori[1] = netacniOdgovori[0];
            odgovori[2] = netacniOdgovori[1];
            odgovori[3] = netacniOdgovori[2];
            Random random = new Random();
            int pozicijaTacnog = 0;
            for (int i = odgovori.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                Zameni(odgovori, i, j);

                if (i == pozicijaTacnog)
                {
                    pozicijaTacnog = j;
                }
                else if (j == pozicijaTacnog)
                {
                    pozicijaTacnog = i;
                }
            }

            return (pozicijaTacnog, odgovori);
        }

        private void Zameni(string[] niz, int i, int j)
        {
            string tren = niz[i];
            niz[i] = niz[j];
            niz[j] = tren;
        }
    }
}
