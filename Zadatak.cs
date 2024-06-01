using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace AgeomProj
{
    public abstract class Zadatak
    {
        public string Pitanje {  get; }
        public TimeSpan VremeZadatak { get; }
        public string Odgovor { get; set; }
        public Zadatak(string pitanje,TimeSpan vreme, string odgovor) 
        { 
            Pitanje = pitanje;
            VremeZadatak = vreme;
            Odgovor = odgovor;
        }
        public void ZapocniOdbrojavanje() 
        {
            /*
            int min = Vreme.Minutes;
            int sek = Vreme.Seconds;
            int ukupnoSek = min * 60 + sek;
            while (ukupnoSek > 0)
            {
                int remainingMinutes = ukupnoSek / 60;
                int remainingSeconds = ukupnoSek % 60;
                Thread.Sleep(1000);
                ukupnoSek--;
            }*/ //ubaci u formu ovu metodu
        }
        public void PauzirajOdbrojavanje()
        { }
    }
}
