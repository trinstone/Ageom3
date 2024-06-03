using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace AgeomProj
{
    public class Nivo<T> where T : Zadatak
    {
        public int TrenutniBrojSrca { get; set; } = 3;
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
        public void UnosIzFajla(string Sadrzaj)
        {
            T[] zadaci = new T[4]; 
            string[] redovi = new string[4];
            for (int i = 0; i < 3; i++)
            {
                redovi[i] = Sadrzaj.Substring(0, Sadrzaj.IndexOf("\r\n"));
                Sadrzaj = Sadrzaj.Remove(0, Sadrzaj.IndexOf("\r\n")+2);
            }
            redovi[3] = Sadrzaj;
            int brojac = 0;
            if (typeof(T)==typeof(SlobodanZadatak))
            {
                while (brojac != 4)
                {
                    string[] infoZad = redovi[brojac].Split('!');
                    string[] temp = infoZad[5].Split(';');
                    PointF pocetnaPoz = new PointF(float.Parse(temp[0]), float.Parse(temp[1]));
                    temp = infoZad[6].Split(';');
                    PointF krajnjaPoz = new PointF(float.Parse(temp[0]), float.Parse(temp[1]));
                    List<IElementSZ> elementi = new List<IElementSZ>();
                    for (int i = 7; i < infoZad.Length; i+=2)
                    {
                        int br = int.Parse(infoZad[i]);
                        switch (br)
                        {
                            default:
                                break;
                            case 1:
                                {
                                    temp = infoZad[i+1].Split(';');
                                    string oznaka = temp[0];
                                    PointF koordinate = new PointF(float.Parse(temp[1]), float.Parse(temp[2]));
                                    Tacka t = new Tacka(koordinate,oznaka);
                                    elementi.Add(t);
                                    break;
                                }
                            case 2:
                                {
                                    temp = infoZad[i+1].Split(';');
                                    Prava p = new Prava(float.Parse(temp[0]), float.Parse(temp[1]));
                                    elementi.Add(p);
                                    break;
                                }
                            case 3:
                                {
                                    temp = infoZad[i + 1].Split(';');
                                    Prava p = new Prava(float.Parse(temp[0]), float.Parse(temp[1]), float.Parse(temp[2]));
                                    elementi.Add(p);
                                    break;
                                }
                            case 4:
                                {
                                    temp = infoZad[i + 1].Split(';');
                                    Krug k = new Krug(new PointF(float.Parse(temp[0]), float.Parse(temp[1])), Convert.ToSingle(Math.Sqrt(float.Parse(temp[2]))));
                                    elementi.Add(k);
                                    break;
                                }
                            case 5:
                                {
                                    temp = infoZad[i + 1].Split(';');
                                    if (float.Parse(temp[1]) < 0)
                                    {
                                        Hiperbola k = new Hiperbola(Convert.ToSingle(Math.Sqrt(float.Parse(temp[0]))), Convert.ToSingle(Math.Sqrt(float.Parse(temp[1]))));
                                        elementi.Add(k);
                                    }
                                    else
                                    {
                                        Elipsa k = new Elipsa(new Point(0,0),Convert.ToSingle(Math.Sqrt(float.Parse(temp[0]))), Convert.ToSingle(Math.Sqrt(float.Parse(temp[1]))));
                                        elementi.Add(k);
                                    }
                                    break;
                                }
                            case 6:
                                {
                                    temp = infoZad[i + 1].Split(';');
                                    Parabola p = new Parabola(float.Parse(temp[0]));
                                    elementi.Add(p);
                                    break;
                                }
                        }
                    }
                    SlobodanZadatak a = new SlobodanZadatak(infoZad[0], TimeSpan.Parse("00:" + infoZad[1]), infoZad[2], (FormaResenja)(Convert.ToInt32(infoZad[3])), infoZad[4],pocetnaPoz,krajnjaPoz,elementi.ToArray());
                    zadaci[brojac] = a as T;
                    brojac++;
                }
            }
            else if (typeof(T) == typeof(KvizZadatak))
            {
                while (brojac != 4)
                {
                    string[] infoZad = redovi[brojac].Split('!');
                    string[] netacniOdg = { infoZad[3], infoZad[4], infoZad[5] };
                    KvizZadatak a = new KvizZadatak(infoZad[0], TimeSpan.Parse(infoZad[1]), infoZad[2], netacniOdg); 
                    zadaci[brojac] = a as T;
                    brojac++;
                }
            }

            Zadaci = zadaci;
        }
        public Nivo(int trenutniBrojSrca, int tezina, params T[] zadaci)
        {
            TrenutniBrojSrca = trenutniBrojSrca;
            Tezina = tezina;
            Zadaci = zadaci;
        }
        public Nivo(int trenutniBrojSrca, int tezina, string imeFajla)
        {
            TrenutniBrojSrca = trenutniBrojSrca;
            Tezina = tezina;
            UnosIzFajla(imeFajla);
        }
        public void Restartuj() { }
        public int GubiZivot() {return TrenutniBrojSrca--;}
    }
}
