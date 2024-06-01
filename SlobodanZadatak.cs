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

        public string Hint { get; }

        public SlobodanZadatak(string pitanje, TimeSpan vreme,string hint,FormaResenja formaResenja, string odgovor, params IElementSZ[] NacrtaniElementi) : base(pitanje, vreme, odgovor)
        {
            elementiSZ = NacrtaniElementi;
            FormaResenja = formaResenja;
            Hint = hint;
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
