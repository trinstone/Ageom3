using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeomProj
{
    public class Krug : IElementSZ
    {
        public PointF[] PozicijaEl { get; }
        public float R { get; }
        public SlobodanZadatak SlobodanZadatak { get; set; }

        public Krug(PointF centar, float r) 
        {
            PozicijaEl = new PointF[1];
            PozicijaEl[0] = centar;
            R = r;
        }   
        public void Nacrtaj(Graphics g, Point centar, int strKvad)
        {
            Pen olovka = new Pen(Color.Black, 3);
            Tacka o = new Tacka(PozicijaEl[0],"O");
            float x = centar.X + strKvad * PozicijaEl[0].X - strKvad * R;
            float y = centar.Y - strKvad * PozicijaEl[0].Y - strKvad * R;
            o.Nacrtaj(g, centar, strKvad);
            g.DrawEllipse(olovka, x, y, 2*R*strKvad, 2*R*strKvad);
        }
    }
}
