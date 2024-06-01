using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace AgeomProj
{
    public class Nivo<T> where T : Zadatak
    {
        public int TrenutniBrojSrca { get; set; } = 3;
        public float TrenutniBrojZvezda { get; set; } = 3;
        public int Tezina { get; set; } 
        public TimeSpan VremeNivo 
        {  get
            {
                Zadatak[] zadaci = Zadaci as Zadatak[];
                TimeSpan ukupno = TimeSpan.Zero;
                for (int i = 0; i < zadaci.Length; i++)
                {
                    ukupno += zadaci[i].VremeZadatak;
                }
                return ukupno;
            } 
        }
        public T[] Zadaci { get; set; }
        private void UnosIzFajla(string imeFajla)
        {
            T[] zadaci = new T[4];
            StreamReader red = new StreamReader(imeFajla);
            int brojac = 0;
            if (typeof(T)==typeof(SlobodanZadatak))
            {
                while (!red.EndOfStream)
                {
                    string[] infoZad = red.ReadLine().Split('!');
                    SlobodanZadatak a = new SlobodanZadatak(infoZad[0], TimeSpan.Parse(infoZad[1]), infoZad[2], (FormaResenja)(Convert.ToInt32(infoZad[3])), infoZad[4]);
                    zadaci[brojac] = a as T;
                    brojac++;
                }
            }
            red.Close();

            Zadaci = zadaci;
        }
        public Nivo(int trenutniBrojSrca, float trenutniBrojZvezda, int tezina, params T[] zadaci)
        {
            TrenutniBrojSrca = trenutniBrojSrca;
            TrenutniBrojZvezda = trenutniBrojZvezda;
            Tezina = tezina;
            Zadaci = zadaci;
        }
        public void Restartuj() { }
        public int GubiZivot() {return TrenutniBrojSrca--;}
    }
}
