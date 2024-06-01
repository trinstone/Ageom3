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
        public PointF PozicijaEl { get; set; }
        public float R { get; set; }
        public SlobodanZadatak SlobodanZadatak { get; set; }

        public Krug(PointF centar, float r) 
        {
            PozicijaEl = centar;
            R = r;
        }   
        public void Nacrtaj(Graphics g, Point centar, int strKvad)
        {
            Pen olovka = new Pen(Color.Black, 3);
            float x = strKvad * PozicijaEl.X + centar.X - strKvad * R;
            float y = strKvad * PozicijaEl.Y + centar.Y - strKvad * R;
            g.DrawEllipse(olovka, x, y, 2*R*strKvad, 2*R*strKvad);
        }
    }
}
