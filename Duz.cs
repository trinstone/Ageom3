using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeomProj
{
    public class Duz : IElementSZ
    {
        public SlobodanZadatak SlobodanZadatak { get; set; }
        public PointF[] PozicijaEl { get; }
        public string[] OznakeTemena { get; }

        public Duz(Tacka A, Tacka B) 
        { 
            PozicijaEl = new PointF[] { A.PozicijaEl[0], B.PozicijaEl[0] };
            OznakeTemena = new string[] { A.Oznaka, B.Oznaka };
        }
        public void Nacrtaj(Graphics g, Point centar, int strKvad)
        {
            new Tacka(PozicijaEl[0], OznakeTemena[0]).Nacrtaj(g, centar, strKvad);
            new Tacka(PozicijaEl[1], OznakeTemena[1]).Nacrtaj(g, centar, strKvad);
            Pen olovka = new Pen(Color.Black, 2);
            PointF t1 = new PointF(centar.X + PozicijaEl[0].X * strKvad, centar.Y - PozicijaEl[0].Y * strKvad);
            PointF t2 = new PointF(centar.X + PozicijaEl[1].X * strKvad, centar.Y - PozicijaEl[1].Y * strKvad);
            g.DrawLine(olovka, t1, t2);
        }
    }
}
