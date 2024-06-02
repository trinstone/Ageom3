using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeomProj
{
    public enum FormaResenja {broj,tacka, pravaEks, pravaImp, krug, elipsaHiperbola, parabola,tekst }
    public class SlobodanZadatak : Zadatak
    {
        
        public FormaResenja FormaResenja {  get; }
        public IElementSZ[] elementiSZ { get; }
        public string[] parametri { get; }
        public string Hint { get; }

        public SlobodanZadatak(string pitanje, TimeSpan vreme,string hint,FormaResenja formaResenja, string odgovor, params IElementSZ[] NacrtaniElementi) : base(pitanje, vreme, odgovor)
        {
            elementiSZ = NacrtaniElementi;
            FormaResenja = formaResenja;
            Hint = hint;
            parametri = new string[3];
            string[] s = odgovor.Split(';');
            if (s.Length == 1)
            {
                parametri[0] = null;
                parametri[1] = null;
                parametri[2] = s[0];
            }
            else if (s.Length == 2)
            {
                parametri[0] = null;
                parametri[1] = s[0];
                parametri[2] = s[1];
            }
            else
            {
                parametri[0] = s[0];
                parametri[1] = s[1];
                parametri[2] = s[2];
            }
        }
        public void Nacrtaj(Graphics g, Point centar, int strKvad)
        {
            foreach (var element in elementiSZ)
            {
                element.Nacrtaj(g, centar, strKvad);
            }
        }
    }
}
