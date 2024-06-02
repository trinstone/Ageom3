using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeomProj
{
    internal class Elipsa:IElementSZ
    {
        public PointF[] PozicijaEl { get; }
        public float A { get; }
        public float B { get; }
        public SlobodanZadatak SlobodanZadatak { get; set; }

        public Elipsa(PointF centar, float a, float b)
        {
            PozicijaEl = new PointF[1];
            PozicijaEl[0] = centar;
            A = a;
            B = b;
        }
        public void Nacrtaj(Graphics g, Point centar, int strKvad)
        {
            Pen olovka = new Pen(Color.Black, 3);
            Tacka o = new Tacka(PozicijaEl[0], "O");
            float x = centar.X + strKvad * PozicijaEl[0].X - strKvad * A;
            float y = centar.Y - strKvad * PozicijaEl[0].Y - strKvad * B;
            o.Nacrtaj(g, centar, strKvad);
            g.DrawEllipse(olovka, x, y, 2 * A * strKvad, 2 * B * strKvad);
        }
    }
}
